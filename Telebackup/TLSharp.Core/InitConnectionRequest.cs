using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLSharp.Core.MTProto;
using TLSharp.Core.Requests;

namespace TLSharp.Core
{
    class InitConnectionRequest : MTProtoRequest
    {
        private int _apiId;
        public ConfigConstructor ConfigConstructor { get; set; }
        public UserConstructor UserConstructor { get; set; }


        public InitConnectionRequest(int apiId)
        {
            _apiId = apiId;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xda9b0d0d); // invokeWithLayer
            writer.Write(38); // (layer to invoke)

            //initConnection#69796de9 {X:Type} 
            writer.Write(0x69796de9); // init connection
            writer.Write(_apiId); // api id
            Serializers.String.Write(writer, Telebackup.Utils.GetPCModel()); // device model
            Serializers.String.Write(writer, Telebackup.Utils.GetOSName()); // system version
            Serializers.String.Write(writer, "0.9-BETA"); // app version
            Serializers.String.Write(writer, "en"); // lang code

            writer.Write(0xc4f9186b); // help.getConfig
        }

        public override void OnResponse(BinaryReader reader)
        {
            uint code = reader.ReadUInt32();

            System.Diagnostics.Debug.WriteLine("code: " + code.ToString("x"));
            ;

            if (code == 0x4e32b894) // config constructor
            {
                ConfigConstructor config = new ConfigConstructor();
                config.Read(reader);
                ConfigConstructor = config;
            }
            else if (code == 0xff036af1) // auth.authorization :/
            {
                Auth_authorizationConstructor auth = new Auth_authorizationConstructor();
                auth.Read(reader);
                UserConstructor = (UserConstructor)auth.user;
            }
            else // TODO something didn't go right...
            {
                if (code == 0xb446ae3) // messages slice still?
                {
                    var result = TL.Parse(reader, code);

                    ;
                }
                else
                    try
                    {
                        while (true) reader.ReadUInt32(); // flush reader, it's the best we can do!
                    }
                    catch (EndOfStreamException) { }
            }
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Responded
        {
            get { return true; }
        }

        public override void OnSendSuccess()
        {

        }
        public override bool Confirmed => true;
    }
}
