using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telebackup
{
    public class HTMLExporter
    {
        #region HTML exporter

        #region Parts

        const string part1 =
    @"<!-- Generated with Telebackup - by Lonami | (C) http://LonamiWebs.TK -->
<!DOCTYPE html><html><head><title>";

        const string part2 =
    @"</title><style>
html { min-height: 100%; }
body { background: linear-gradient(#dde3e7, #ccd3d7); }
h1, h2, p { font-family: ""Trebuchet MS"", Helvetica, sans-serif; }
div.main { padding: 20px 10px; }
table { width: 100%; }
td div {
	padding: 2px 10px;
	border-radius: 2px;
	display: inline-block;
	margin: 5px;
}
td.su div {
	background-color: #effdde;
	float: right;
}
td.cu div {
	background-color: #ffffff;
	float: left;
}
td.arrow {
	width: 1%;
	white-space: nowrap;
}
.arrow-right {
	width: 0;
	height: 0;
	border-top: 10px solid transparent;
	border-bottom: 10px solid transparent;
	border-left: 20px solid #effdde;
	border-radius: 5px;
	margin: -12px;
}
.arrow-left {
	width: 0; 
	height: 0; 
	border-top: 10px solid transparent;
	border-bottom: 10px solid transparent; 
	border-right: 20px solid #ffffff; 
	margin-right: -12px;
}
h1, h2 { text-align: center; }
h1 { font-size: 42px; }
div.date { text-align: center; }
div.date h2 {
	font-size: 14px;
	background-color: #b4c0cd;
    color: #ffffff;
	padding: 5px;
	border-radius: 5px;
	margin-left: auto;
	margin-right: auto;
	display: inline-block;
}
span.sufwd { color: #40902e; }
span.cufwd { color: #1c81d1; }
span.name { font-size: 18px; }
span.date {
	font-size: 12px;
	float: right;
	color: #a4b2be;
	padding: 15px 0px 0px 8px;
}
span.Msg { font-size: 14px; }
</style></head><body><div class=""main""><h1>";

        const string part3 = @"</h1><table>";
        const string part4 = @"</table></div></body></html>";

        const string msg_self_fw1 = @"<p><span class=""sufwd"">Forwarded from ";
        const string msg_self_fw2 = @"</span></p>";
        const string msg_self1 = @"<tr><td></td><td></td><td class=""su""><div>";
        const string msg_self6 =
    @"</span></p></div></td><td class=""arrow""><div class=""arrow-right""></div></td></tr>";

        const string msg_contact_fw1 = @"<p><span class=""cufwd"">Forwarded from ";
        const string msg_contact_fw2 = @"</span></p>";
        const string msg_contact1 =
    @"<tr><td class=""arrow""><div class=""arrow-left""></div></td><td class=""cu""><div>";
        const string msg_contact6 = @"</span></p></div></td><td></td><td></td></tr>";

        const string msg2 = @"<p><span class=""name"">";
        const string msg3 = @"</span></p><p><span class=""Msg"">";
        const string msg4 = @"</span><span class=""date"" title=""";
        const string msg5 = @""">";

        const string info1 = @"</table><div class=""date""><h2>";
        const string info2 = @"</h2></div><table>";

        #endregion

        public static string GenerateHTML(string title, List<Msg> Messages)
        {
            var sb = new StringBuilder();
            sb.Append(part1);
            sb.Append(title);
            sb.Append(part2);
            sb.Append(title);
            sb.Append(part3);

            DateTime lastDate = new DateTime(1900, 1, 1);

            // TODO implement reply to, msg photo, etc, etc
            foreach (var msg in Messages)
            {
                if (Utils.DifferentDay(lastDate, msg.Date))
                {
                    lastDate = msg.Date;

                    sb.Append(info1);
                    sb.Append(lastDate.Year == msg.Date.Year ?
                        msg.Date.ToString("MMMM d") :
                        msg.Date.ToString("yyyy MMMM d"));
                    sb.Append(info2);
                }
                if (!string.IsNullOrEmpty(msg.Action)) // It is an action Msg
                {
                    sb.Append(info1);
                    sb.Append(msg.Action);
                    sb.Append(info2);
                    continue;
                }

                sb.Append(msg.Self ? msg_self1 : msg_contact1);
                if (!string.IsNullOrEmpty(msg.Forwarded))
                {
                    sb.Append(msg.Self ? msg_self_fw1 : msg_contact_fw1);
                    sb.Append(msg.Forwarded);
                    sb.Append(msg.Self ? msg_self_fw2 : msg_contact_fw2);
                }
                sb.Append(msg2);
                sb.Append(msg.Sender);
                sb.Append(msg3);
                sb.Append(msg.Content.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\n", "<br/>"));
                sb.Append(msg4);
                sb.Append(msg.Date.ToLongDateString());
                sb.Append(' ');
                sb.Append(msg.Date.ToLongTimeString());
                sb.Append(msg5);
                sb.Append(msg.Date.ToString("HH:mm"));
                sb.Append(msg.Self ? msg_self6 : msg_contact6);
            }
            sb.Append(part4);

            return sb.ToString();
        }

        #endregion
    }
}
