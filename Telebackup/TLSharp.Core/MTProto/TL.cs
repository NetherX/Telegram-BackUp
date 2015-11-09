using System;
using System.Collections.Generic;
using System.IO;
using TLSharp.Core.Requests;

namespace TLSharp.Core.MTProto
{

    public abstract class TLObject
    {
        public abstract Constructor Constructor { get; }
        public abstract void Write(BinaryWriter writer);
        public abstract void Read(BinaryReader reader);
    }

    // All constructor types
    public enum Constructor
    {
        msgs_ack,
        bad_msg_notification,
        bad_server_salt,
        msgs_state_req,
        msgs_state_info,
        msgs_all_info,
        msg_detailed_info,
        msg_new_detailed_info,
        msg_resend_req,
        rpc_error,
        rpc_answer_unknown,
        rpc_answer_dropped_running,
        rpc_answer_dropped,
        future_salt,
        pong,
        destroy_session_ok,
        destroy_session_none,
        new_session_created,
        http_wait,
        error,
        @null,
        inputPeerEmpty,
        inputPeerSelf,
        inputPeerChat,
        inputPeerUser,
        inputPeerChannel,
        inputUserEmpty,
        inputUserSelf,
        inputUser,
        inputPhoneContact,
        inputFile,
        inputFileBig,
        inputMediaEmpty,
        inputMediaUploadedPhoto,
        inputMediaPhoto,
        inputMediaGeoPoint,
        inputMediaContact,
        inputMediaUploadedVideo,
        inputMediaUploadedThumbVideo,
        inputMediaVideo,
        inputMediaUploadedAudio,
        inputMediaAudio,
        inputMediaUploadedDocument,
        inputMediaUploadedThumbDocument,
        inputMediaDocument,
        inputMediaVenue,
        inputChatPhotoEmpty,
        inputChatUploadedPhoto,
        inputChatPhoto,
        inputGeoPointEmpty,
        inputGeoPoint,
        inputPhotoEmpty,
        inputPhoto,
        inputVideoEmpty,
        inputVideo,
        inputFileLocation,
        inputVideoFileLocation,
        inputEncryptedFileLocation,
        inputAudioFileLocation,
        inputDocumentFileLocation,
        inputPhotoCropAuto,
        inputPhotoCrop,
        inputAppEvent,
        peerUser,
        peerChat,
        peerChannel,
        storage_fileUnknown,
        storage_fileJpeg,
        storage_fileGif,
        storage_filePng,
        storage_filePdf,
        storage_fileMp3,
        storage_fileMov,
        storage_filePartial,
        storage_fileMp4,
        storage_fileWebp,
        fileLocationUnavailable,
        fileLocation,
        userEmpty,
        user,
        userProfilePhotoEmpty,
        userProfilePhoto,
        userStatusEmpty,
        userStatusOnline,
        userStatusOffline,
        userStatusRecently,
        userStatusLastWeek,
        userStatusLastMonth,
        chatEmpty,
        chat,
        chatForbidden,
        channel,
        channelForbidden,
        chatFull,
        channelFull,
        chatParticipant,
        chatParticipantsForbidden,
        chatParticipants,
        chatPhotoEmpty,
        chatPhoto,
        messageEmpty,
        message,
        messageService,
        messageMediaEmpty,
        messageMediaPhoto,
        messageMediaVideo,
        messageMediaGeo,
        messageMediaContact,
        messageMediaUnsupported,
        messageMediaDocument,
        messageMediaAudio,
        messageMediaWebPage,
        messageMediaVenue,
        messageActionEmpty,
        messageActionChatCreate,
        messageActionChatEditTitle,
        messageActionChatEditPhoto,
        messageActionChatDeletePhoto,
        messageActionChatAddUser,
        messageActionChatDeleteUser,
        messageActionChatJoinedByLink,
        messageActionChannelCreate,
        dialog,
        dialogChannel,
        photoEmpty,
        photo,
        photoSizeEmpty,
        photoSize,
        photoCachedSize,
        videoEmpty,
        video,
        geoPointEmpty,
        geoPoint,
        auth_checkedPhone,
        auth_sentCode,
        auth_sentAppCode,
        auth_authorization,
        auth_exportedAuthorization,
        inputNotifyPeer,
        inputNotifyUsers,
        inputNotifyChats,
        inputNotifyAll,
        inputPeerNotifyEventsEmpty,
        inputPeerNotifyEventsAll,
        inputPeerNotifySettings,
        peerNotifyEventsEmpty,
        peerNotifyEventsAll,
        peerNotifySettingsEmpty,
        peerNotifySettings,
        wallPaper,
        wallPaperSolid,
        userFull,
        contact,
        importedContact,
        contactBlocked,
        contactSuggested,
        contactStatus,
        contacts_link,
        contacts_contactsNotModified,
        contacts_contacts,
        contacts_importedContacts,
        contacts_blocked,
        contacts_blockedSlice,
        contacts_suggested,
        messages_dialogs,
        messages_dialogsSlice,
        messages_messages,
        messages_messagesSlice,
        messages_channelMessages,
        messages_chats,
        messages_chatFull,
        messages_affectedHistory,
        inputMessagesFilterEmpty,
        inputMessagesFilterPhotos,
        inputMessagesFilterVideo,
        inputMessagesFilterPhotoVideo,
        inputMessagesFilterPhotoVideoDocuments,
        inputMessagesFilterDocument,
        inputMessagesFilterAudio,
        inputMessagesFilterAudioDocuments,
        inputMessagesFilterUrl,
        updateNewMessage,
        updateMessageID,
        updateDeleteMessages,
        updateUserTyping,
        updateChatUserTyping,
        updateChatParticipants,
        updateUserStatus,
        updateUserName,
        updateUserPhoto,
        updateContactRegistered,
        updateContactLink,
        updateNewAuthorization,
        updateNewEncryptedMessage,
        updateEncryptedChatTyping,
        updateEncryption,
        updateEncryptedMessagesRead,
        updateChatParticipantAdd,
        updateChatParticipantDelete,
        updateDcOptions,
        updateUserBlocked,
        updateNotifySettings,
        updateServiceNotification,
        updatePrivacy,
        updateUserPhone,
        updateReadHistoryInbox,
        updateReadHistoryOutbox,
        updateWebPage,
        updateReadMessagesContents,
        updateChannelTooLong,
        updateChannel,
        updateChannelGroup,
        updateNewChannelMessage,
        updateReadChannelInbox,
        updateDeleteChannelMessages,
        updateChannelMessageViews,
        updates_state,
        updates_differenceEmpty,
        updates_difference,
        updates_differenceSlice,
        updatesTooLong,
        updateShortMessage,
        updateShortChatMessage,
        updateShort,
        updatesCombined,
        updates,
        updateShortSentMessage,
        photos_photos,
        photos_photosSlice,
        photos_photo,
        upload_file,
        dcOption,
        config,
        nearestDc,
        help_appUpdate,
        help_noAppUpdate,
        help_inviteText,
        encryptedChatEmpty,
        encryptedChatWaiting,
        encryptedChatRequested,
        encryptedChat,
        encryptedChatDiscarded,
        inputEncryptedChat,
        encryptedFileEmpty,
        encryptedFile,
        inputEncryptedFileEmpty,
        inputEncryptedFileUploaded,
        inputEncryptedFile,
        inputEncryptedFileBigUploaded,
        encryptedMessage,
        encryptedMessageService,
        messages_dhConfigNotModified,
        messages_dhConfig,
        messages_sentEncryptedMessage,
        messages_sentEncryptedFile,
        inputAudioEmpty,
        inputAudio,
        inputDocumentEmpty,
        inputDocument,
        audioEmpty,
        audio,
        documentEmpty,
        document,
        help_support,
        notifyPeer,
        notifyUsers,
        notifyChats,
        notifyAll,
        sendMessageTypingAction,
        sendMessageCancelAction,
        sendMessageRecordVideoAction,
        sendMessageUploadVideoAction,
        sendMessageRecordAudioAction,
        sendMessageUploadAudioAction,
        sendMessageUploadPhotoAction,
        sendMessageUploadDocumentAction,
        sendMessageGeoLocationAction,
        sendMessageChooseContactAction,
        contacts_found,
        inputPrivacyKeyStatusTimestamp,
        privacyKeyStatusTimestamp,
        inputPrivacyValueAllowContacts,
        inputPrivacyValueAllowAll,
        inputPrivacyValueAllowUsers,
        inputPrivacyValueDisallowContacts,
        inputPrivacyValueDisallowAll,
        inputPrivacyValueDisallowUsers,
        privacyValueAllowContacts,
        privacyValueAllowAll,
        privacyValueAllowUsers,
        privacyValueDisallowContacts,
        privacyValueDisallowAll,
        privacyValueDisallowUsers,
        account_privacyRules,
        accountDaysTTL,
        account_sentChangePhoneCode,
        documentAttributeImageSize,
        documentAttributeAnimated,
        documentAttributeSticker,
        documentAttributeVideo,
        documentAttributeAudio,
        documentAttributeFilename,
        messages_stickersNotModified,
        messages_stickers,
        stickerPack,
        messages_allStickersNotModified,
        messages_allStickers,
        disabledFeature,
        messages_affectedMessages,
        contactLinkUnknown,
        contactLinkNone,
        contactLinkHasPhone,
        contactLinkContact,
        webPageEmpty,
        webPagePending,
        webPage,
        authorization,
        account_authorizations,
        account_noPassword,
        account_password,
        account_passwordSettings,
        account_passwordInputSettings,
        auth_passwordRecovery,
        receivedNotifyMessage,
        chatInviteEmpty,
        chatInviteExported,
        chatInviteAlready,
        chatInvite,
        inputStickerSetEmpty,
        inputStickerSetID,
        inputStickerSetShortName,
        stickerSet,
        messages_stickerSet,
        botCommand,
        botInfoEmpty,
        botInfo,
        keyboardButton,
        keyboardButtonRow,
        replyKeyboardHide,
        replyKeyboardForceReply,
        replyKeyboardMarkup,
        help_appChangelogEmpty,
        help_appChangelog,
        messageEntityUnknown,
        messageEntityMention,
        messageEntityHashtag,
        messageEntityBotCommand,
        messageEntityUrl,
        messageEntityEmail,
        messageEntityBold,
        messageEntityItalic,
        messageEntityCode,
        messageEntityPre,
        messageEntityTextUrl,
        inputChannelEmpty,
        inputChannel,
        contacts_resolvedPeer,
        messageRange,
        messageGroup,
        updates_channelDifferenceEmpty,
        updates_channelDifferenceTooLong,
        updates_channelDifference,
        channelMessagesFilterEmpty,
        channelMessagesFilter,
        channelMessagesFilterCollapsed,
        channelParticipant,
        channelParticipantSelf,
        channelParticipantModerator,
        channelParticipantEditor,
        channelParticipantKicked,
        channelParticipantCreator,
        channelParticipantsRecent,
        channelParticipantsAdmins,
        channelParticipantsKicked,
        channelRoleEmpty,
        channelRoleModerator,
        channelRoleEditor,
        channels_channelParticipants,
        channels_channelParticipant
    }

    public class TL
    {
        static Dictionary<uint, Type> constructors = new Dictionary<uint, Type>()
    {
        { 0x62d6b459, typeof(Msgs_ackConstructor) },
        { 0xa7eff811, typeof(Bad_msg_notificationConstructor) },
        { 0xedab447b, typeof(Bad_server_saltConstructor) },
        { 0xda69fb52, typeof(Msgs_state_reqConstructor) },
        { 0x04deb57d, typeof(Msgs_state_infoConstructor) },
        { 0x8cc0d131, typeof(Msgs_all_infoConstructor) },
        { 0x276d3ec6, typeof(Msg_detailed_infoConstructor) },
        { 0x809db6df, typeof(Msg_new_detailed_infoConstructor) },
        { 0x7d861a08, typeof(Msg_resend_reqConstructor) },
        { 0x2144ca19, typeof(Rpc_errorConstructor) },
        { 0x5e2ad36e, typeof(Rpc_answer_unknownConstructor) },
        { 0xcd78e586, typeof(Rpc_answer_dropped_runningConstructor) },
        { 0xa43ad8b7, typeof(Rpc_answer_droppedConstructor) },
        { 0x0949d9dc, typeof(Future_saltConstructor) },
        { 0x347773c5, typeof(PongConstructor) },
        { 0xe22045fc, typeof(Destroy_session_okConstructor) },
        { 0x62d350c9, typeof(Destroy_session_noneConstructor) },
        { 0x9ec20908, typeof(New_session_createdConstructor) },
        { 0x9299359f, typeof(Http_waitConstructor) },
        { 0xc4b9f9bb, typeof(ErrorConstructor) },
        { 0x56730bcc, typeof(@nullConstructor) },
        { 0x7f3b18ea, typeof(InputPeerEmptyConstructor) },
        { 0x7da07ec9, typeof(InputPeerSelfConstructor) },
        { 0x179be863, typeof(InputPeerChatConstructor) },
        { 0x7b8e7de6, typeof(InputPeerUserConstructor) },
        { 0x20adaef8, typeof(InputPeerChannelConstructor) },
        { 0xb98886cf, typeof(InputUserEmptyConstructor) },
        { 0xf7c1b13f, typeof(InputUserSelfConstructor) },
        { 0xd8292816, typeof(InputUserConstructor) },
        { 0xf392b7f4, typeof(InputPhoneContactConstructor) },
        { 0xf52ff27f, typeof(InputFileConstructor) },
        { 0xfa4f0bb5, typeof(InputFileBigConstructor) },
        { 0x9664f57f, typeof(InputMediaEmptyConstructor) },
        { 0xf7aff1c0, typeof(InputMediaUploadedPhotoConstructor) },
        { 0xe9bfb4f3, typeof(InputMediaPhotoConstructor) },
        { 0xf9c44144, typeof(InputMediaGeoPointConstructor) },
        { 0xa6e45987, typeof(InputMediaContactConstructor) },
        { 0x82713fdf, typeof(InputMediaUploadedVideoConstructor) },
        { 0x7780ddf9, typeof(InputMediaUploadedThumbVideoConstructor) },
        { 0x936a4ebd, typeof(InputMediaVideoConstructor) },
        { 0x4e498cab, typeof(InputMediaUploadedAudioConstructor) },
        { 0x89938781, typeof(InputMediaAudioConstructor) },
        { 0xffe76b78, typeof(InputMediaUploadedDocumentConstructor) },
        { 0x41481486, typeof(InputMediaUploadedThumbDocumentConstructor) },
        { 0xd184e841, typeof(InputMediaDocumentConstructor) },
        { 0x2827a81a, typeof(InputMediaVenueConstructor) },
        { 0x1ca48f57, typeof(InputChatPhotoEmptyConstructor) },
        { 0x94254732, typeof(InputChatUploadedPhotoConstructor) },
        { 0xb2e1bf08, typeof(InputChatPhotoConstructor) },
        { 0xe4c123d6, typeof(InputGeoPointEmptyConstructor) },
        { 0xf3b7acc9, typeof(InputGeoPointConstructor) },
        { 0x1cd7bf0d, typeof(InputPhotoEmptyConstructor) },
        { 0xfb95c6c4, typeof(InputPhotoConstructor) },
        { 0x5508ec75, typeof(InputVideoEmptyConstructor) },
        { 0xee579652, typeof(InputVideoConstructor) },
        { 0x14637196, typeof(InputFileLocationConstructor) },
        { 0x3d0364ec, typeof(InputVideoFileLocationConstructor) },
        { 0xf5235d55, typeof(InputEncryptedFileLocationConstructor) },
        { 0x74dc404d, typeof(InputAudioFileLocationConstructor) },
        { 0x4e45abe9, typeof(InputDocumentFileLocationConstructor) },
        { 0xade6b004, typeof(InputPhotoCropAutoConstructor) },
        { 0xd9915325, typeof(InputPhotoCropConstructor) },
        { 0x770656a8, typeof(InputAppEventConstructor) },
        { 0x9db1bc6d, typeof(PeerUserConstructor) },
        { 0xbad0e5bb, typeof(PeerChatConstructor) },
        { 0xbddde532, typeof(PeerChannelConstructor) },
        { 0xaa963b05, typeof(Storage_fileUnknownConstructor) },
        { 0x7efe0e, typeof(Storage_fileJpegConstructor) },
        { 0xcae1aadf, typeof(Storage_fileGifConstructor) },
        { 0xa4f63c0, typeof(Storage_filePngConstructor) },
        { 0xae1e508d, typeof(Storage_filePdfConstructor) },
        { 0x528a0677, typeof(Storage_fileMp3Constructor) },
        { 0x4b09ebbc, typeof(Storage_fileMovConstructor) },
        { 0x40bc6f52, typeof(Storage_filePartialConstructor) },
        { 0xb3cea0e4, typeof(Storage_fileMp4Constructor) },
        { 0x1081464c, typeof(Storage_fileWebpConstructor) },
        { 0x7c596b46, typeof(FileLocationUnavailableConstructor) },
        { 0x53d69076, typeof(FileLocationConstructor) },
        { 0x200250ba, typeof(UserEmptyConstructor) },
        { 0x22e49072, typeof(UserConstructor) },
        { 0x4f11bae1, typeof(UserProfilePhotoEmptyConstructor) },
        { 0xd559d8c8, typeof(UserProfilePhotoConstructor) },
        { 0x9d05049, typeof(UserStatusEmptyConstructor) },
        { 0xedb93949, typeof(UserStatusOnlineConstructor) },
        { 0x8c703f, typeof(UserStatusOfflineConstructor) },
        { 0xe26f42f1, typeof(UserStatusRecentlyConstructor) },
        { 0x7bf09fc, typeof(UserStatusLastWeekConstructor) },
        { 0x77ebc742, typeof(UserStatusLastMonthConstructor) },
        { 0x9ba2d800, typeof(ChatEmptyConstructor) },
        { 0x7312bc48, typeof(ChatConstructor) },
        { 0x7328bdb, typeof(ChatForbiddenConstructor) },
        { 0x678e9587, typeof(ChannelConstructor) },
        { 0x2d85832c, typeof(ChannelForbiddenConstructor) },
        { 0x2e02a614, typeof(ChatFullConstructor) },
        { 0xfab31aa3, typeof(ChannelFullConstructor) },
        { 0xc8d7493e, typeof(ChatParticipantConstructor) },
        { 0xfc900c2b, typeof(ChatParticipantsForbiddenConstructor) },
        { 0x7841b415, typeof(ChatParticipantsConstructor) },
        { 0x37c1011c, typeof(ChatPhotoEmptyConstructor) },
        { 0x6153276a, typeof(ChatPhotoConstructor) },
        { 0x83e5de54, typeof(MessageEmptyConstructor) },
        { 0x5ba66c13, typeof(MessageConstructor) },
        { 0xc06b9607, typeof(MessageServiceConstructor) },
        { 0x3ded6320, typeof(MessageMediaEmptyConstructor) },
        { 0x3d8ce53d, typeof(MessageMediaPhotoConstructor) },
        { 0x5bcf1675, typeof(MessageMediaVideoConstructor) },
        { 0x56e0d474, typeof(MessageMediaGeoConstructor) },
        { 0x5e7d2f39, typeof(MessageMediaContactConstructor) },
        { 0x9f84f49e, typeof(MessageMediaUnsupportedConstructor) },
        { 0x2fda2204, typeof(MessageMediaDocumentConstructor) },
        { 0xc6b68300, typeof(MessageMediaAudioConstructor) },
        { 0xa32dd600, typeof(MessageMediaWebPageConstructor) },
        { 0x7912b71f, typeof(MessageMediaVenueConstructor) },
        { 0xb6aef7b0, typeof(MessageActionEmptyConstructor) },
        { 0xa6638b9a, typeof(MessageActionChatCreateConstructor) },
        { 0xb5a1ce5a, typeof(MessageActionChatEditTitleConstructor) },
        { 0x7fcb13a8, typeof(MessageActionChatEditPhotoConstructor) },
        { 0x95e3fbef, typeof(MessageActionChatDeletePhotoConstructor) },
        { 0x5e3cfc4b, typeof(MessageActionChatAddUserConstructor) },
        { 0xb2ae9b0c, typeof(MessageActionChatDeleteUserConstructor) },
        { 0xf89cf5e8, typeof(MessageActionChatJoinedByLinkConstructor) },
        { 0x95d2ac92, typeof(MessageActionChannelCreateConstructor) },
        { 0xc1dd804a, typeof(DialogConstructor) },
        { 0x5b8496b2, typeof(DialogChannelConstructor) },
        { 0x2331b22d, typeof(PhotoEmptyConstructor) },
        { 0xcded42fe, typeof(PhotoConstructor) },
        { 0xe17e23c, typeof(PhotoSizeEmptyConstructor) },
        { 0x77bfb61b, typeof(PhotoSizeConstructor) },
        { 0xe9a734fa, typeof(PhotoCachedSizeConstructor) },
        { 0xc10658a8, typeof(VideoEmptyConstructor) },
        { 0xf72887d3, typeof(VideoConstructor) },
        { 0x1117dd5f, typeof(GeoPointEmptyConstructor) },
        { 0x2049d70c, typeof(GeoPointConstructor) },
        { 0x811ea28e, typeof(Auth_checkedPhoneConstructor) },
        { 0xefed51d9, typeof(Auth_sentCodeConstructor) },
        { 0xe325edcf, typeof(Auth_sentAppCodeConstructor) },
        { 0xff036af1, typeof(Auth_authorizationConstructor) },
        { 0xdf969c2d, typeof(Auth_exportedAuthorizationConstructor) },
        { 0xb8bc5b0c, typeof(InputNotifyPeerConstructor) },
        { 0x193b4417, typeof(InputNotifyUsersConstructor) },
        { 0x4a95e84e, typeof(InputNotifyChatsConstructor) },
        { 0xa429b886, typeof(InputNotifyAllConstructor) },
        { 0xf03064d8, typeof(InputPeerNotifyEventsEmptyConstructor) },
        { 0xe86a2c74, typeof(InputPeerNotifyEventsAllConstructor) },
        { 0x46a2ce98, typeof(InputPeerNotifySettingsConstructor) },
        { 0xadd53cb3, typeof(PeerNotifyEventsEmptyConstructor) },
        { 0x6d1ded88, typeof(PeerNotifyEventsAllConstructor) },
        { 0x70a68512, typeof(PeerNotifySettingsEmptyConstructor) },
        { 0x8d5e11ee, typeof(PeerNotifySettingsConstructor) },
        { 0xccb03657, typeof(WallPaperConstructor) },
        { 0x63117f24, typeof(WallPaperSolidConstructor) },
        { 0x5a89ac5b, typeof(UserFullConstructor) },
        { 0xf911c994, typeof(ContactConstructor) },
        { 0xd0028438, typeof(ImportedContactConstructor) },
        { 0x561bc879, typeof(ContactBlockedConstructor) },
        { 0x3de191a1, typeof(ContactSuggestedConstructor) },
        { 0xd3680c61, typeof(ContactStatusConstructor) },
        { 0x3ace484c, typeof(Contacts_linkConstructor) },
        { 0xb74ba9d2, typeof(Contacts_contactsNotModifiedConstructor) },
        { 0x6f8b8cb2, typeof(Contacts_contactsConstructor) },
        { 0xad524315, typeof(Contacts_importedContactsConstructor) },
        { 0x1c138d15, typeof(Contacts_blockedConstructor) },
        { 0x900802a1, typeof(Contacts_blockedSliceConstructor) },
        { 0x5649dcc5, typeof(Contacts_suggestedConstructor) },
        { 0x15ba6c40, typeof(Messages_dialogsConstructor) },
        { 0x71e094f3, typeof(Messages_dialogsSliceConstructor) },
        { 0x8c718e87, typeof(Messages_messagesConstructor) },
        { 0xb446ae3, typeof(Messages_messagesSliceConstructor) },
        { 0xbc0f17bc, typeof(Messages_channelMessagesConstructor) },
        { 0x64ff9fd5, typeof(Messages_chatsConstructor) },
        { 0xe5d7d19c, typeof(Messages_chatFullConstructor) },
        { 0xb45c69d1, typeof(Messages_affectedHistoryConstructor) },
        { 0x57e2f66c, typeof(InputMessagesFilterEmptyConstructor) },
        { 0x9609a51c, typeof(InputMessagesFilterPhotosConstructor) },
        { 0x9fc00e65, typeof(InputMessagesFilterVideoConstructor) },
        { 0x56e9f0e4, typeof(InputMessagesFilterPhotoVideoConstructor) },
        { 0xd95e73bb, typeof(InputMessagesFilterPhotoVideoDocumentsConstructor) },
        { 0x9eddf188, typeof(InputMessagesFilterDocumentConstructor) },
        { 0xcfc87522, typeof(InputMessagesFilterAudioConstructor) },
        { 0x5afbf764, typeof(InputMessagesFilterAudioDocumentsConstructor) },
        { 0x7ef0dd87, typeof(InputMessagesFilterUrlConstructor) },
        { 0x1f2b0afd, typeof(UpdateNewMessageConstructor) },
        { 0x4e90bfd6, typeof(UpdateMessageIDConstructor) },
        { 0xa20db0e5, typeof(UpdateDeleteMessagesConstructor) },
        { 0x5c486927, typeof(UpdateUserTypingConstructor) },
        { 0x9a65ea1f, typeof(UpdateChatUserTypingConstructor) },
        { 0x7761198, typeof(UpdateChatParticipantsConstructor) },
        { 0x1bfbd823, typeof(UpdateUserStatusConstructor) },
        { 0xa7332b73, typeof(UpdateUserNameConstructor) },
        { 0x95313b0c, typeof(UpdateUserPhotoConstructor) },
        { 0x2575bbb9, typeof(UpdateContactRegisteredConstructor) },
        { 0x9d2e67c5, typeof(UpdateContactLinkConstructor) },
        { 0x8f06529a, typeof(UpdateNewAuthorizationConstructor) },
        { 0x12bcbd9a, typeof(UpdateNewEncryptedMessageConstructor) },
        { 0x1710f156, typeof(UpdateEncryptedChatTypingConstructor) },
        { 0xb4a2e88d, typeof(UpdateEncryptionConstructor) },
        { 0x38fe25b7, typeof(UpdateEncryptedMessagesReadConstructor) },
        { 0xea4b0e5c, typeof(UpdateChatParticipantAddConstructor) },
        { 0x6e5f8c22, typeof(UpdateChatParticipantDeleteConstructor) },
        { 0x8e5e9873, typeof(UpdateDcOptionsConstructor) },
        { 0x80ece81a, typeof(UpdateUserBlockedConstructor) },
        { 0xbec268ef, typeof(UpdateNotifySettingsConstructor) },
        { 0x382dd3e4, typeof(UpdateServiceNotificationConstructor) },
        { 0xee3b272a, typeof(UpdatePrivacyConstructor) },
        { 0x12b9417b, typeof(UpdateUserPhoneConstructor) },
        { 0x9961fd5c, typeof(UpdateReadHistoryInboxConstructor) },
        { 0x2f2f21bf, typeof(UpdateReadHistoryOutboxConstructor) },
        { 0x7f891213, typeof(UpdateWebPageConstructor) },
        { 0x68c13933, typeof(UpdateReadMessagesContentsConstructor) },
        { 0x60946422, typeof(UpdateChannelTooLongConstructor) },
        { 0xb6d45656, typeof(UpdateChannelConstructor) },
        { 0xc36c1e3c, typeof(UpdateChannelGroupConstructor) },
        { 0x62ba04d9, typeof(UpdateNewChannelMessageConstructor) },
        { 0x4214f37f, typeof(UpdateReadChannelInboxConstructor) },
        { 0xc37521c9, typeof(UpdateDeleteChannelMessagesConstructor) },
        { 0x98a12b4b, typeof(UpdateChannelMessageViewsConstructor) },
        { 0xa56c2a3e, typeof(Updates_stateConstructor) },
        { 0x5d75a138, typeof(Updates_differenceEmptyConstructor) },
        { 0xf49ca0, typeof(Updates_differenceConstructor) },
        { 0xa8fb1981, typeof(Updates_differenceSliceConstructor) },
        { 0xe317af7e, typeof(UpdatesTooLongConstructor) },
        { 0xf7d91a46, typeof(UpdateShortMessageConstructor) },
        { 0xcac7fdd2, typeof(UpdateShortChatMessageConstructor) },
        { 0x78d4dec1, typeof(UpdateShortConstructor) },
        { 0x725b04c3, typeof(UpdatesCombinedConstructor) },
        { 0x74ae4240, typeof(UpdatesConstructor) },
        { 0x11f1331c, typeof(UpdateShortSentMessageConstructor) },
        { 0x8dca6aa5, typeof(Photos_photosConstructor) },
        { 0x15051f54, typeof(Photos_photosSliceConstructor) },
        { 0x20212ca8, typeof(Photos_photoConstructor) },
        { 0x96a18d5, typeof(Upload_fileConstructor) },
        { 0x5d8c6cc, typeof(DcOptionConstructor) },
        { 0x4e32b894, typeof(ConfigConstructor) },
        { 0x8e1a1775, typeof(NearestDcConstructor) },
        { 0x8987f311, typeof(Help_appUpdateConstructor) },
        { 0xc45a6536, typeof(Help_noAppUpdateConstructor) },
        { 0x18cb9f78, typeof(Help_inviteTextConstructor) },
        { 0xab7ec0a0, typeof(EncryptedChatEmptyConstructor) },
        { 0x3bf703dc, typeof(EncryptedChatWaitingConstructor) },
        { 0xc878527e, typeof(EncryptedChatRequestedConstructor) },
        { 0xfa56ce36, typeof(EncryptedChatConstructor) },
        { 0x13d6dd27, typeof(EncryptedChatDiscardedConstructor) },
        { 0xf141b5e1, typeof(InputEncryptedChatConstructor) },
        { 0xc21f497e, typeof(EncryptedFileEmptyConstructor) },
        { 0x4a70994c, typeof(EncryptedFileConstructor) },
        { 0x1837c364, typeof(InputEncryptedFileEmptyConstructor) },
        { 0x64bd0306, typeof(InputEncryptedFileUploadedConstructor) },
        { 0x5a17b5e5, typeof(InputEncryptedFileConstructor) },
        { 0x2dc173c8, typeof(InputEncryptedFileBigUploadedConstructor) },
        { 0xed18c118, typeof(EncryptedMessageConstructor) },
        { 0x23734b06, typeof(EncryptedMessageServiceConstructor) },
        { 0xc0e24635, typeof(Messages_dhConfigNotModifiedConstructor) },
        { 0x2c221edd, typeof(Messages_dhConfigConstructor) },
        { 0x560f8935, typeof(Messages_sentEncryptedMessageConstructor) },
        { 0x9493ff32, typeof(Messages_sentEncryptedFileConstructor) },
        { 0xd95adc84, typeof(InputAudioEmptyConstructor) },
        { 0x77d440ff, typeof(InputAudioConstructor) },
        { 0x72f0eaae, typeof(InputDocumentEmptyConstructor) },
        { 0x18798952, typeof(InputDocumentConstructor) },
        { 0x586988d8, typeof(AudioEmptyConstructor) },
        { 0xf9e35055, typeof(AudioConstructor) },
        { 0x36f8c871, typeof(DocumentEmptyConstructor) },
        { 0xf9a39f4f, typeof(DocumentConstructor) },
        { 0x17c6b5f6, typeof(Help_supportConstructor) },
        { 0x9fd40bd8, typeof(NotifyPeerConstructor) },
        { 0xb4c83b4c, typeof(NotifyUsersConstructor) },
        { 0xc007cec3, typeof(NotifyChatsConstructor) },
        { 0x74d07c60, typeof(NotifyAllConstructor) },
        { 0x16bf744e, typeof(SendMessageTypingActionConstructor) },
        { 0xfd5ec8f5, typeof(SendMessageCancelActionConstructor) },
        { 0xa187d66f, typeof(SendMessageRecordVideoActionConstructor) },
        { 0xe9763aec, typeof(SendMessageUploadVideoActionConstructor) },
        { 0xd52f73f7, typeof(SendMessageRecordAudioActionConstructor) },
        { 0xf351d7ab, typeof(SendMessageUploadAudioActionConstructor) },
        { 0xd1d34a26, typeof(SendMessageUploadPhotoActionConstructor) },
        { 0xaa0cd9e4, typeof(SendMessageUploadDocumentActionConstructor) },
        { 0x176f8ba1, typeof(SendMessageGeoLocationActionConstructor) },
        { 0x628cbc6f, typeof(SendMessageChooseContactActionConstructor) },
        { 0x1aa1f784, typeof(Contacts_foundConstructor) },
        { 0x4f96cb18, typeof(InputPrivacyKeyStatusTimestampConstructor) },
        { 0xbc2eab30, typeof(PrivacyKeyStatusTimestampConstructor) },
        { 0xd09e07b, typeof(InputPrivacyValueAllowContactsConstructor) },
        { 0x184b35ce, typeof(InputPrivacyValueAllowAllConstructor) },
        { 0x131cc67f, typeof(InputPrivacyValueAllowUsersConstructor) },
        { 0xba52007, typeof(InputPrivacyValueDisallowContactsConstructor) },
        { 0xd66b66c9, typeof(InputPrivacyValueDisallowAllConstructor) },
        { 0x90110467, typeof(InputPrivacyValueDisallowUsersConstructor) },
        { 0xfffe1bac, typeof(PrivacyValueAllowContactsConstructor) },
        { 0x65427b82, typeof(PrivacyValueAllowAllConstructor) },
        { 0x4d5bbe0c, typeof(PrivacyValueAllowUsersConstructor) },
        { 0xf888fa1a, typeof(PrivacyValueDisallowContactsConstructor) },
        { 0x8b73e763, typeof(PrivacyValueDisallowAllConstructor) },
        { 0xc7f49b7, typeof(PrivacyValueDisallowUsersConstructor) },
        { 0x554abb6f, typeof(Account_privacyRulesConstructor) },
        { 0xb8d0afdf, typeof(AccountDaysTTLConstructor) },
        { 0xa4f58c4c, typeof(Account_sentChangePhoneCodeConstructor) },
        { 0x6c37c15c, typeof(DocumentAttributeImageSizeConstructor) },
        { 0x11b58939, typeof(DocumentAttributeAnimatedConstructor) },
        { 0x3a556302, typeof(DocumentAttributeStickerConstructor) },
        { 0x5910cccb, typeof(DocumentAttributeVideoConstructor) },
        { 0xded218e0, typeof(DocumentAttributeAudioConstructor) },
        { 0x15590068, typeof(DocumentAttributeFilenameConstructor) },
        { 0xf1749a22, typeof(Messages_stickersNotModifiedConstructor) },
        { 0x8a8ecd32, typeof(Messages_stickersConstructor) },
        { 0x12b299d4, typeof(StickerPackConstructor) },
        { 0xe86602c3, typeof(Messages_allStickersNotModifiedConstructor) },
        { 0xd51dafdb, typeof(Messages_allStickersConstructor) },
        { 0xae636f24, typeof(DisabledFeatureConstructor) },
        { 0x84d19185, typeof(Messages_affectedMessagesConstructor) },
        { 0x5f4f9247, typeof(ContactLinkUnknownConstructor) },
        { 0xfeedd3ad, typeof(ContactLinkNoneConstructor) },
        { 0x268f3f59, typeof(ContactLinkHasPhoneConstructor) },
        { 0xd502c2d0, typeof(ContactLinkContactConstructor) },
        { 0xeb1477e8, typeof(WebPageEmptyConstructor) },
        { 0xc586da1c, typeof(WebPagePendingConstructor) },
        { 0xca820ed7, typeof(WebPageConstructor) },
        { 0x7bf2e6f6, typeof(AuthorizationConstructor) },
        { 0x1250abde, typeof(Account_authorizationsConstructor) },
        { 0x96dabc18, typeof(Account_noPasswordConstructor) },
        { 0x7c18141c, typeof(Account_passwordConstructor) },
        { 0xb7b72ab3, typeof(Account_passwordSettingsConstructor) },
        { 0xbcfc532c, typeof(Account_passwordInputSettingsConstructor) },
        { 0x137948a5, typeof(Auth_passwordRecoveryConstructor) },
        { 0xa384b779, typeof(ReceivedNotifyMessageConstructor) },
        { 0x69df3769, typeof(ChatInviteEmptyConstructor) },
        { 0xfc2e05bc, typeof(ChatInviteExportedConstructor) },
        { 0x5a686d7c, typeof(ChatInviteAlreadyConstructor) },
        { 0x93e99b60, typeof(ChatInviteConstructor) },
        { 0xffb62b95, typeof(InputStickerSetEmptyConstructor) },
        { 0x9de7a269, typeof(InputStickerSetIDConstructor) },
        { 0x861cc8a0, typeof(InputStickerSetShortNameConstructor) },
        { 0xcd303b41, typeof(StickerSetConstructor) },
        { 0xb60a24a6, typeof(Messages_stickerSetConstructor) },
        { 0xc27ac8c7, typeof(BotCommandConstructor) },
        { 0xbb2e37ce, typeof(BotInfoEmptyConstructor) },
        { 0x9cf585d, typeof(BotInfoConstructor) },
        { 0xa2fa4880, typeof(KeyboardButtonConstructor) },
        { 0x77608b83, typeof(KeyboardButtonRowConstructor) },
        { 0xa03e5b85, typeof(ReplyKeyboardHideConstructor) },
        { 0xf4108aa0, typeof(ReplyKeyboardForceReplyConstructor) },
        { 0x3502758c, typeof(ReplyKeyboardMarkupConstructor) },
        { 0xaf7e0394, typeof(Help_appChangelogEmptyConstructor) },
        { 0x4668e6bd, typeof(Help_appChangelogConstructor) },
        { 0xbb92ba95, typeof(MessageEntityUnknownConstructor) },
        { 0xfa04579d, typeof(MessageEntityMentionConstructor) },
        { 0x6f635b0d, typeof(MessageEntityHashtagConstructor) },
        { 0x6cef8ac7, typeof(MessageEntityBotCommandConstructor) },
        { 0x6ed02538, typeof(MessageEntityUrlConstructor) },
        { 0x64e475c2, typeof(MessageEntityEmailConstructor) },
        { 0xbd610bc9, typeof(MessageEntityBoldConstructor) },
        { 0x826f8b60, typeof(MessageEntityItalicConstructor) },
        { 0x28a20571, typeof(MessageEntityCodeConstructor) },
        { 0x73924be0, typeof(MessageEntityPreConstructor) },
        { 0x76a6d327, typeof(MessageEntityTextUrlConstructor) },
        { 0xee8c1e86, typeof(InputChannelEmptyConstructor) },
        { 0xafeb712e, typeof(InputChannelConstructor) },
        { 0x7f077ad9, typeof(Contacts_resolvedPeerConstructor) },
        { 0xae30253, typeof(MessageRangeConstructor) },
        { 0xe8346f53, typeof(MessageGroupConstructor) },
        { 0x3e11affb, typeof(Updates_channelDifferenceEmptyConstructor) },
        { 0x5e167646, typeof(Updates_channelDifferenceTooLongConstructor) },
        { 0x2064674e, typeof(Updates_channelDifferenceConstructor) },
        { 0x94d42ee7, typeof(ChannelMessagesFilterEmptyConstructor) },
        { 0xcd77d957, typeof(ChannelMessagesFilterConstructor) },
        { 0xfa01232e, typeof(ChannelMessagesFilterCollapsedConstructor) },
        { 0x15ebac1d, typeof(ChannelParticipantConstructor) },
        { 0xa3289a6d, typeof(ChannelParticipantSelfConstructor) },
        { 0x91057fef, typeof(ChannelParticipantModeratorConstructor) },
        { 0x98192d61, typeof(ChannelParticipantEditorConstructor) },
        { 0x8cc5e69a, typeof(ChannelParticipantKickedConstructor) },
        { 0xe3e2e1f9, typeof(ChannelParticipantCreatorConstructor) },
        { 0xde3f3c79, typeof(ChannelParticipantsRecentConstructor) },
        { 0xb4608969, typeof(ChannelParticipantsAdminsConstructor) },
        { 0x3c37bb7a, typeof(ChannelParticipantsKickedConstructor) },
        { 0xb285a0c6, typeof(ChannelRoleEmptyConstructor) },
        { 0x9618d975, typeof(ChannelRoleModeratorConstructor) },
        { 0x820bfe8c, typeof(ChannelRoleEditorConstructor) },
        { 0xf56ee2a8, typeof(Channels_channelParticipantsConstructor) },
        { 0xd0d9b163, typeof(channels_ChannelParticipant) }
    };

        public static TLObject Parse(BinaryReader reader, uint code)
        {
            if (!constructors.ContainsKey(code))
                throw new Exception("unknown constructor code");

            uint dataCode = reader.ReadUInt32();
            if (dataCode != code)
                throw new Exception(string.Format("target code {0} != data code {1}",
                    code, dataCode));

            TLObject obj = (TLObject)Activator.CreateInstance(constructors[code]);
            obj.Read(reader);
            return obj;
        }

        public static T Parse<T>(BinaryReader reader)
        {
            if (typeof(TLObject).IsAssignableFrom(typeof(T)))
            {
                uint dataCode = reader.ReadUInt32();

                if (!constructors.ContainsKey(dataCode))
                    throw new Exception(String.Format("invalid constructor code {0}", dataCode));

                Type constructorType = constructors[dataCode];
                if (!typeof(T).IsAssignableFrom(constructorType))
                    throw new Exception(String.Format("try to parse {0}, but incompatible type {1}",
                        typeof(T).FullName, constructorType.FullName));

                T obj = (T)Activator.CreateInstance(constructorType);
                ((TLObject)(object)obj).Read(reader);
                return obj;
            }
            else if (typeof(T) == typeof(bool))
            {
                uint code = reader.ReadUInt32();
                if (code == 0x997275b5)
                    return (T)(object)true;

                else if (code == 0xbc799737)
                    return (T)(object)false;

                else
                    throw new Exception("unknown bool value");
            }
            else
                throw new Exception("unknown return type");
        }

        // Constructors
        public static MsgsAck msgs_ack(List<long> msg_ids)
        {
            return new Msgs_ackConstructor(msg_ids);
        }

        public static BadMsgNotification bad_msg_notification(long bad_msg_id, int bad_msg_seqno, int error_code)
        {
            return new Bad_msg_notificationConstructor(bad_msg_id, bad_msg_seqno, error_code);
        }

        public static BadMsgNotification bad_server_salt(long bad_msg_id, int bad_msg_seqno, int error_code, long new_server_salt)
        {
            return new Bad_server_saltConstructor(bad_msg_id, bad_msg_seqno, error_code, new_server_salt);
        }

        public static MsgsStateReq msgs_state_req(List<long> msg_ids)
        {
            return new Msgs_state_reqConstructor(msg_ids);
        }

        public static MsgsStateInfo msgs_state_info(long req_msg_id, string info)
        {
            return new Msgs_state_infoConstructor(req_msg_id, info);
        }

        public static MsgsAllInfo msgs_all_info(List<long> msg_ids, string info)
        {
            return new Msgs_all_infoConstructor(msg_ids, info);
        }

        public static MsgDetailedInfo msg_detailed_info(long msg_id, long answer_msg_id, int bytes, int status)
        {
            return new Msg_detailed_infoConstructor(msg_id, answer_msg_id, bytes, status);
        }

        public static MsgDetailedInfo msg_new_detailed_info(long answer_msg_id, int bytes, int status)
        {
            return new Msg_new_detailed_infoConstructor(answer_msg_id, bytes, status);
        }

        public static MsgResendReq msg_resend_req(List<long> msg_ids)
        {
            return new Msg_resend_reqConstructor(msg_ids);
        }

        public static RpcError rpc_error(int error_code, string error_message)
        {
            return new Rpc_errorConstructor(error_code, error_message);
        }

        public static RpcDropAnswer rpc_answer_unknown()
        {
            return new Rpc_answer_unknownConstructor();
        }

        public static RpcDropAnswer rpc_answer_dropped_running()
        {
            return new Rpc_answer_dropped_runningConstructor();
        }

        public static RpcDropAnswer rpc_answer_dropped(long msg_id, int seq_no, int bytes)
        {
            return new Rpc_answer_droppedConstructor(msg_id, seq_no, bytes);
        }

        public static FutureSalt future_salt(int valid_since, int valid_until, long salt)
        {
            return new Future_saltConstructor(valid_since, valid_until, salt);
        }

        public static Pong pong(long msg_id, long ping_id)
        {
            return new PongConstructor(msg_id, ping_id);
        }

        public static DestroySessionRes destroy_session_ok(long session_id)
        {
            return new Destroy_session_okConstructor(session_id);
        }

        public static DestroySessionRes destroy_session_none(long session_id)
        {
            return new Destroy_session_noneConstructor(session_id);
        }

        public static NewSession new_session_created(long first_msg_id, long unique_id, long server_salt)
        {
            return new New_session_createdConstructor(first_msg_id, unique_id, server_salt);
        }

        public static HttpWait http_wait(int max_delay, int wait_after, int max_wait)
        {
            return new Http_waitConstructor(max_delay, wait_after, max_wait);
        }

        public static Error error(int code, string text)
        {
            return new ErrorConstructor(code, text);
        }

        public static Null @null()
        {
            return new @nullConstructor();
        }

        public static InputPeer inputPeerEmpty()
        {
            return new InputPeerEmptyConstructor();
        }

        public static InputPeer inputPeerSelf()
        {
            return new InputPeerSelfConstructor();
        }

        public static InputPeer inputPeerChat(int chat_id)
        {
            return new InputPeerChatConstructor(chat_id);
        }

        public static InputPeer inputPeerUser(int user_id, long access_hash)
        {
            return new InputPeerUserConstructor(user_id, access_hash);
        }

        public static InputPeer inputPeerChannel(int channel_id, long access_hash)
        {
            return new InputPeerChannelConstructor(channel_id, access_hash);
        }

        public static InputUser inputUserEmpty()
        {
            return new InputUserEmptyConstructor();
        }

        public static InputUser inputUserSelf()
        {
            return new InputUserSelfConstructor();
        }

        public static InputUser inputUser(int user_id, long access_hash)
        {
            return new InputUserConstructor(user_id, access_hash);
        }

        public static InputContact inputPhoneContact(long client_id, string phone, string first_name, string last_name)
        {
            return new InputPhoneContactConstructor(client_id, phone, first_name, last_name);
        }

        public static InputFile inputFile(long id, int parts, string name, string md5_checksum)
        {
            return new InputFileConstructor(id, parts, name, md5_checksum);
        }

        public static InputFile inputFileBig(long id, int parts, string name)
        {
            return new InputFileBigConstructor(id, parts, name);
        }

        public static InputMedia inputMediaEmpty()
        {
            return new InputMediaEmptyConstructor();
        }

        public static InputMedia inputMediaUploadedPhoto(InputFile file, string caption)
        {
            return new InputMediaUploadedPhotoConstructor(file, caption);
        }

        public static InputMedia inputMediaPhoto(InputPhoto id, string caption)
        {
            return new InputMediaPhotoConstructor(id, caption);
        }

        public static InputMedia inputMediaGeoPoint(InputGeoPoint geo_point)
        {
            return new InputMediaGeoPointConstructor(geo_point);
        }

        public static InputMedia inputMediaContact(string phone_number, string first_name, string last_name)
        {
            return new InputMediaContactConstructor(phone_number, first_name, last_name);
        }

        public static InputMedia inputMediaUploadedVideo(InputFile file, int duration, int w, int h, string mime_type, string caption)
        {
            return new InputMediaUploadedVideoConstructor(file, duration, w, h, mime_type, caption);
        }

        public static InputMedia inputMediaUploadedThumbVideo(InputFile file, InputFile thumb, int duration, int w, int h, string mime_type, string caption)
        {
            return new InputMediaUploadedThumbVideoConstructor(file, thumb, duration, w, h, mime_type, caption);
        }

        public static InputMedia inputMediaVideo(InputVideo id, string caption)
        {
            return new InputMediaVideoConstructor(id, caption);
        }

        public static InputMedia inputMediaUploadedAudio(InputFile file, int duration, string mime_type)
        {
            return new InputMediaUploadedAudioConstructor(file, duration, mime_type);
        }

        public static InputMedia inputMediaAudio(InputAudio id)
        {
            return new InputMediaAudioConstructor(id);
        }

        public static InputMedia inputMediaUploadedDocument(InputFile file, string mime_type, List<DocumentAttribute> attributes)
        {
            return new InputMediaUploadedDocumentConstructor(file, mime_type, attributes);
        }

        public static InputMedia inputMediaUploadedThumbDocument(InputFile file, InputFile thumb, string mime_type, List<DocumentAttribute> attributes)
        {
            return new InputMediaUploadedThumbDocumentConstructor(file, thumb, mime_type, attributes);
        }

        public static InputMedia inputMediaDocument(InputDocument id)
        {
            return new InputMediaDocumentConstructor(id);
        }

        public static InputMedia inputMediaVenue(InputGeoPoint geo_point, string title, string address, string provider, string venue_id)
        {
            return new InputMediaVenueConstructor(geo_point, title, address, provider, venue_id);
        }

        public static InputChatPhoto inputChatPhotoEmpty()
        {
            return new InputChatPhotoEmptyConstructor();
        }

        public static InputChatPhoto inputChatUploadedPhoto(InputFile file, InputPhotoCrop crop)
        {
            return new InputChatUploadedPhotoConstructor(file, crop);
        }

        public static InputChatPhoto inputChatPhoto(InputPhoto id, InputPhotoCrop crop)
        {
            return new InputChatPhotoConstructor(id, crop);
        }

        public static InputGeoPoint inputGeoPointEmpty()
        {
            return new InputGeoPointEmptyConstructor();
        }

        public static InputGeoPoint inputGeoPoint(double lat, double @long)
        {
            return new InputGeoPointConstructor(lat, @long);
        }

        public static InputPhoto inputPhotoEmpty()
        {
            return new InputPhotoEmptyConstructor();
        }

        public static InputPhoto inputPhoto(long id, long access_hash)
        {
            return new InputPhotoConstructor(id, access_hash);
        }

        public static InputVideo inputVideoEmpty()
        {
            return new InputVideoEmptyConstructor();
        }

        public static InputVideo inputVideo(long id, long access_hash)
        {
            return new InputVideoConstructor(id, access_hash);
        }

        public static InputFileLocation inputFileLocation(long volume_id, int local_id, long secret)
        {
            return new InputFileLocationConstructor(volume_id, local_id, secret);
        }

        public static InputFileLocation inputVideoFileLocation(long id, long access_hash)
        {
            return new InputVideoFileLocationConstructor(id, access_hash);
        }

        public static InputFileLocation inputEncryptedFileLocation(long id, long access_hash)
        {
            return new InputEncryptedFileLocationConstructor(id, access_hash);
        }

        public static InputFileLocation inputAudioFileLocation(long id, long access_hash)
        {
            return new InputAudioFileLocationConstructor(id, access_hash);
        }

        public static InputFileLocation inputDocumentFileLocation(long id, long access_hash)
        {
            return new InputDocumentFileLocationConstructor(id, access_hash);
        }

        public static InputPhotoCrop inputPhotoCropAuto()
        {
            return new InputPhotoCropAutoConstructor();
        }

        public static InputPhotoCrop inputPhotoCrop(double crop_left, double crop_top, double crop_width)
        {
            return new InputPhotoCropConstructor(crop_left, crop_top, crop_width);
        }

        public static InputAppEvent inputAppEvent(double time, string type, long peer, string data)
        {
            return new InputAppEventConstructor(time, type, peer, data);
        }

        public static Peer peerUser(int user_id)
        {
            return new PeerUserConstructor(user_id);
        }

        public static Peer peerChat(int chat_id)
        {
            return new PeerChatConstructor(chat_id);
        }

        public static Peer peerChannel(int channel_id)
        {
            return new PeerChannelConstructor(channel_id);
        }

        public static storage_FileType storage_fileUnknown()
        {
            return new Storage_fileUnknownConstructor();
        }

        public static storage_FileType storage_fileJpeg()
        {
            return new Storage_fileJpegConstructor();
        }

        public static storage_FileType storage_fileGif()
        {
            return new Storage_fileGifConstructor();
        }

        public static storage_FileType storage_filePng()
        {
            return new Storage_filePngConstructor();
        }

        public static storage_FileType storage_filePdf()
        {
            return new Storage_filePdfConstructor();
        }

        public static storage_FileType storage_fileMp3()
        {
            return new Storage_fileMp3Constructor();
        }

        public static storage_FileType storage_fileMov()
        {
            return new Storage_fileMovConstructor();
        }

        public static storage_FileType storage_filePartial()
        {
            return new Storage_filePartialConstructor();
        }

        public static storage_FileType storage_fileMp4()
        {
            return new Storage_fileMp4Constructor();
        }

        public static storage_FileType storage_fileWebp()
        {
            return new Storage_fileWebpConstructor();
        }

        public static FileLocation fileLocationUnavailable(long volume_id, int local_id, long secret)
        {
            return new FileLocationUnavailableConstructor(volume_id, local_id, secret);
        }

        public static FileLocation fileLocation(int dc_id, long volume_id, int local_id, long secret)
        {
            return new FileLocationConstructor(dc_id, volume_id, local_id, secret);
        }

        public static User userEmpty(int id)
        {
            return new UserEmptyConstructor(id);
        }

        public static User user(int flags, int id, long? access_hash, string first_name, string last_name, string username, string phone, UserProfilePhoto photo, UserStatus status, int? bot_info_version)
        {
            return new UserConstructor(flags, id, access_hash, first_name, last_name, username, phone, photo, status, bot_info_version);
        }

        public static UserProfilePhoto userProfilePhotoEmpty()
        {
            return new UserProfilePhotoEmptyConstructor();
        }

        public static UserProfilePhoto userProfilePhoto(long photo_id, FileLocation photo_small, FileLocation photo_big)
        {
            return new UserProfilePhotoConstructor(photo_id, photo_small, photo_big);
        }

        public static UserStatus userStatusEmpty()
        {
            return new UserStatusEmptyConstructor();
        }

        public static UserStatus userStatusOnline(int expires)
        {
            return new UserStatusOnlineConstructor(expires);
        }

        public static UserStatus userStatusOffline(int was_online)
        {
            return new UserStatusOfflineConstructor(was_online);
        }

        public static UserStatus userStatusRecently()
        {
            return new UserStatusRecentlyConstructor();
        }

        public static UserStatus userStatusLastWeek()
        {
            return new UserStatusLastWeekConstructor();
        }

        public static UserStatus userStatusLastMonth()
        {
            return new UserStatusLastMonthConstructor();
        }

        public static Chat chatEmpty(int id)
        {
            return new ChatEmptyConstructor(id);
        }

        public static Chat chat(int flags, int id, string title, ChatPhoto photo, int participants_count, int date, int version)
        {
            return new ChatConstructor(flags, id, title, photo, participants_count, date, version);
        }

        public static Chat chatForbidden(int id, string title)
        {
            return new ChatForbiddenConstructor(id, title);
        }

        public static Chat channel(int flags, int id, long access_hash, string title, string username, ChatPhoto photo, int date, int version)
        {
            return new ChannelConstructor(flags, id, access_hash, title, username, photo, date, version);
        }

        public static Chat channelForbidden(int id, long access_hash, string title)
        {
            return new ChannelForbiddenConstructor(id, access_hash, title);
        }

        public static ChatFull chatFull(int id, ChatParticipants participants, Photo chat_photo, PeerNotifySettings notify_settings, ExportedChatInvite exported_invite, List<BotInfo> bot_info)
        {
            return new ChatFullConstructor(id, participants, chat_photo, notify_settings, exported_invite, bot_info);
        }

        public static ChatFull channelFull(int flags, int id, string about, int? participants_count, int? admins_count, int? kicked_count, int read_inbox_max_id, int unread_count, int unread_important_count, Photo chat_photo, PeerNotifySettings notify_settings, ExportedChatInvite exported_invite)
        {
            return new ChannelFullConstructor(flags, id, about, participants_count, admins_count, kicked_count, read_inbox_max_id, unread_count, unread_important_count, chat_photo, notify_settings, exported_invite);
        }

        public static ChatParticipant chatParticipant(int user_id, int inviter_id, int date)
        {
            return new ChatParticipantConstructor(user_id, inviter_id, date);
        }

        public static ChatParticipants chatParticipantsForbidden(int flags, int chat_id, ChatParticipant self_participant)
        {
            return new ChatParticipantsForbiddenConstructor(flags, chat_id, self_participant);
        }

        public static ChatParticipants chatParticipants(int chat_id, int admin_id, List<ChatParticipant> participants, int version)
        {
            return new ChatParticipantsConstructor(chat_id, admin_id, participants, version);
        }

        public static ChatPhoto chatPhotoEmpty()
        {
            return new ChatPhotoEmptyConstructor();
        }

        public static ChatPhoto chatPhoto(FileLocation photo_small, FileLocation photo_big)
        {
            return new ChatPhotoConstructor(photo_small, photo_big);
        }

        public static Message messageEmpty(int id)
        {
            return new MessageEmptyConstructor(id);
        }

        public static Message message(int flags, int id, int? from_id, Peer to_id, Peer fwd_from_id, int? fwd_date, int? reply_to_msg_id, int date, string message, MessageMedia media, ReplyMarkup reply_markup, List<MessageEntity> entities, int? views)
        {
            return new MessageConstructor(flags, id, from_id, to_id, fwd_from_id, fwd_date, reply_to_msg_id, date, message, media, reply_markup, entities, views);
        }

        public static Message messageService(int flags, int id, int? from_id, Peer to_id, int date, MessageAction action)
        {
            return new MessageServiceConstructor(flags, id, from_id, to_id, date, action);
        }

        public static MessageMedia messageMediaEmpty()
        {
            return new MessageMediaEmptyConstructor();
        }

        public static MessageMedia messageMediaPhoto(Photo photo, string caption)
        {
            return new MessageMediaPhotoConstructor(photo, caption);
        }

        public static MessageMedia messageMediaVideo(Video video, string caption)
        {
            return new MessageMediaVideoConstructor(video, caption);
        }

        public static MessageMedia messageMediaGeo(GeoPoint geo)
        {
            return new MessageMediaGeoConstructor(geo);
        }

        public static MessageMedia messageMediaContact(string phone_number, string first_name, string last_name, int user_id)
        {
            return new MessageMediaContactConstructor(phone_number, first_name, last_name, user_id);
        }

        public static MessageMedia messageMediaUnsupported()
        {
            return new MessageMediaUnsupportedConstructor();
        }

        public static MessageMedia messageMediaDocument(Document document)
        {
            return new MessageMediaDocumentConstructor(document);
        }

        public static MessageMedia messageMediaAudio(Audio audio)
        {
            return new MessageMediaAudioConstructor(audio);
        }

        public static MessageMedia messageMediaWebPage(WebPage webpage)
        {
            return new MessageMediaWebPageConstructor(webpage);
        }

        public static MessageMedia messageMediaVenue(GeoPoint geo, string title, string address, string provider, string venue_id)
        {
            return new MessageMediaVenueConstructor(geo, title, address, provider, venue_id);
        }

        public static MessageAction messageActionEmpty()
        {
            return new MessageActionEmptyConstructor();
        }

        public static MessageAction messageActionChatCreate(string title, List<int> users)
        {
            return new MessageActionChatCreateConstructor(title, users);
        }

        public static MessageAction messageActionChatEditTitle(string title)
        {
            return new MessageActionChatEditTitleConstructor(title);
        }

        public static MessageAction messageActionChatEditPhoto(Photo photo)
        {
            return new MessageActionChatEditPhotoConstructor(photo);
        }

        public static MessageAction messageActionChatDeletePhoto()
        {
            return new MessageActionChatDeletePhotoConstructor();
        }

        public static MessageAction messageActionChatAddUser(int user_id)
        {
            return new MessageActionChatAddUserConstructor(user_id);
        }

        public static MessageAction messageActionChatDeleteUser(int user_id)
        {
            return new MessageActionChatDeleteUserConstructor(user_id);
        }

        public static MessageAction messageActionChatJoinedByLink(int inviter_id)
        {
            return new MessageActionChatJoinedByLinkConstructor(inviter_id);
        }

        public static MessageAction messageActionChannelCreate(string title)
        {
            return new MessageActionChannelCreateConstructor(title);
        }

        public static Dialog dialog(Peer peer, int top_message, int read_inbox_max_id, int unread_count, PeerNotifySettings notify_settings)
        {
            return new DialogConstructor(peer, top_message, read_inbox_max_id, unread_count, notify_settings);
        }

        public static Dialog dialogChannel(Peer peer, int top_message, int top_important_message, int read_inbox_max_id, int unread_count, int unread_important_count, PeerNotifySettings notify_settings, int pts)
        {
            return new DialogChannelConstructor(peer, top_message, top_important_message, read_inbox_max_id, unread_count, unread_important_count, notify_settings, pts);
        }

        public static Photo photoEmpty(long id)
        {
            return new PhotoEmptyConstructor(id);
        }

        public static Photo photo(long id, long access_hash, int date, List<PhotoSize> sizes)
        {
            return new PhotoConstructor(id, access_hash, date, sizes);
        }

        public static PhotoSize photoSizeEmpty(string type)
        {
            return new PhotoSizeEmptyConstructor(type);
        }

        public static PhotoSize photoSize(string type, FileLocation location, int w, int h, int size)
        {
            return new PhotoSizeConstructor(type, location, w, h, size);
        }

        public static PhotoSize photoCachedSize(string type, FileLocation location, int w, int h, byte[] bytes)
        {
            return new PhotoCachedSizeConstructor(type, location, w, h, bytes);
        }

        public static Video videoEmpty(long id)
        {
            return new VideoEmptyConstructor(id);
        }

        public static Video video(long id, long access_hash, int date, int duration, string mime_type, int size, PhotoSize thumb, int dc_id, int w, int h)
        {
            return new VideoConstructor(id, access_hash, date, duration, mime_type, size, thumb, dc_id, w, h);
        }

        public static GeoPoint geoPointEmpty()
        {
            return new GeoPointEmptyConstructor();
        }

        public static GeoPoint geoPoint(double @long, double lat)
        {
            return new GeoPointConstructor(@long, lat);
        }

        public static auth_CheckedPhone auth_checkedPhone(bool phone_registered)
        {
            return new Auth_checkedPhoneConstructor(phone_registered);
        }

        public static auth_SentCode auth_sentCode(bool phone_registered, string phone_code_hash, int send_call_timeout, bool is_password)
        {
            return new Auth_sentCodeConstructor(phone_registered, phone_code_hash, send_call_timeout, is_password);
        }

        public static auth_SentCode auth_sentAppCode(bool phone_registered, string phone_code_hash, int send_call_timeout, bool is_password)
        {
            return new Auth_sentAppCodeConstructor(phone_registered, phone_code_hash, send_call_timeout, is_password);
        }

        public static auth_Authorization auth_authorization(User user)
        {
            return new Auth_authorizationConstructor(user);
        }

        public static auth_ExportedAuthorization auth_exportedAuthorization(int id, byte[] bytes)
        {
            return new Auth_exportedAuthorizationConstructor(id, bytes);
        }

        public static InputNotifyPeer inputNotifyPeer(InputPeer peer)
        {
            return new InputNotifyPeerConstructor(peer);
        }

        public static InputNotifyPeer inputNotifyUsers()
        {
            return new InputNotifyUsersConstructor();
        }

        public static InputNotifyPeer inputNotifyChats()
        {
            return new InputNotifyChatsConstructor();
        }

        public static InputNotifyPeer inputNotifyAll()
        {
            return new InputNotifyAllConstructor();
        }

        public static InputPeerNotifyEvents inputPeerNotifyEventsEmpty()
        {
            return new InputPeerNotifyEventsEmptyConstructor();
        }

        public static InputPeerNotifyEvents inputPeerNotifyEventsAll()
        {
            return new InputPeerNotifyEventsAllConstructor();
        }

        public static InputPeerNotifySettings inputPeerNotifySettings(int mute_until, string sound, bool show_previews, int events_mask)
        {
            return new InputPeerNotifySettingsConstructor(mute_until, sound, show_previews, events_mask);
        }

        public static PeerNotifyEvents peerNotifyEventsEmpty()
        {
            return new PeerNotifyEventsEmptyConstructor();
        }

        public static PeerNotifyEvents peerNotifyEventsAll()
        {
            return new PeerNotifyEventsAllConstructor();
        }

        public static PeerNotifySettings peerNotifySettingsEmpty()
        {
            return new PeerNotifySettingsEmptyConstructor();
        }

        public static PeerNotifySettings peerNotifySettings(int mute_until, string sound, bool show_previews, int events_mask)
        {
            return new PeerNotifySettingsConstructor(mute_until, sound, show_previews, events_mask);
        }

        public static WallPaper wallPaper(int id, string title, List<PhotoSize> sizes, int color)
        {
            return new WallPaperConstructor(id, title, sizes, color);
        }

        public static WallPaper wallPaperSolid(int id, string title, int bg_color, int color)
        {
            return new WallPaperSolidConstructor(id, title, bg_color, color);
        }

        public static UserFull userFull(User user, contacts_Link link, Photo profile_photo, PeerNotifySettings notify_settings, bool blocked, BotInfo bot_info)
        {
            return new UserFullConstructor(user, link, profile_photo, notify_settings, blocked, bot_info);
        }

        public static Contact contact(int user_id, bool mutual)
        {
            return new ContactConstructor(user_id, mutual);
        }

        public static ImportedContact importedContact(int user_id, long client_id)
        {
            return new ImportedContactConstructor(user_id, client_id);
        }

        public static ContactBlocked contactBlocked(int user_id, int date)
        {
            return new ContactBlockedConstructor(user_id, date);
        }

        public static ContactSuggested contactSuggested(int user_id, int mutual_contacts)
        {
            return new ContactSuggestedConstructor(user_id, mutual_contacts);
        }

        public static ContactStatus contactStatus(int user_id, UserStatus status)
        {
            return new ContactStatusConstructor(user_id, status);
        }

        public static contacts_Link contacts_link(ContactLink my_link, ContactLink foreign_link, User user)
        {
            return new Contacts_linkConstructor(my_link, foreign_link, user);
        }

        public static contacts_Contacts contacts_contactsNotModified()
        {
            return new Contacts_contactsNotModifiedConstructor();
        }

        public static contacts_Contacts contacts_contacts(List<Contact> contacts, List<User> users)
        {
            return new Contacts_contactsConstructor(contacts, users);
        }

        public static contacts_ImportedContacts contacts_importedContacts(List<ImportedContact> imported, List<long> retry_contacts, List<User> users)
        {
            return new Contacts_importedContactsConstructor(imported, retry_contacts, users);
        }

        public static contacts_Blocked contacts_blocked(List<ContactBlocked> blocked, List<User> users)
        {
            return new Contacts_blockedConstructor(blocked, users);
        }

        public static contacts_Blocked contacts_blockedSlice(int count, List<ContactBlocked> blocked, List<User> users)
        {
            return new Contacts_blockedSliceConstructor(count, blocked, users);
        }

        public static contacts_Suggested contacts_suggested(List<ContactSuggested> results, List<User> users)
        {
            return new Contacts_suggestedConstructor(results, users);
        }

        public static messages_Dialogs messages_dialogs(List<Dialog> dialogs, List<Message> messages, List<Chat> chats, List<User> users)
        {
            return new Messages_dialogsConstructor(dialogs, messages, chats, users);
        }

        public static messages_Dialogs messages_dialogsSlice(int count, List<Dialog> dialogs, List<Message> messages, List<Chat> chats, List<User> users)
        {
            return new Messages_dialogsSliceConstructor(count, dialogs, messages, chats, users);
        }

        public static messages_Messages messages_messages(List<Message> messages, List<Chat> chats, List<User> users)
        {
            return new Messages_messagesConstructor(messages, chats, users);
        }

        public static messages_Messages messages_messagesSlice(int count, List<Message> messages, List<Chat> chats, List<User> users)
        {
            return new Messages_messagesSliceConstructor(count, messages, chats, users);
        }

        public static messages_Messages messages_channelMessages(int flags, int pts, int count, List<Message> messages, List<MessageGroup> collapsed, List<Chat> chats, List<User> users)
        {
            return new Messages_channelMessagesConstructor(flags, pts, count, messages, collapsed, chats, users);
        }

        public static messages_Chats messages_chats(List<Chat> chats)
        {
            return new Messages_chatsConstructor(chats);
        }

        public static messages_ChatFull messages_chatFull(ChatFull full_chat, List<Chat> chats, List<User> users)
        {
            return new Messages_chatFullConstructor(full_chat, chats, users);
        }

        public static messages_AffectedHistory messages_affectedHistory(int pts, int pts_count, int offset)
        {
            return new Messages_affectedHistoryConstructor(pts, pts_count, offset);
        }

        public static MessagesFilter inputMessagesFilterEmpty()
        {
            return new InputMessagesFilterEmptyConstructor();
        }

        public static MessagesFilter inputMessagesFilterPhotos()
        {
            return new InputMessagesFilterPhotosConstructor();
        }

        public static MessagesFilter inputMessagesFilterVideo()
        {
            return new InputMessagesFilterVideoConstructor();
        }

        public static MessagesFilter inputMessagesFilterPhotoVideo()
        {
            return new InputMessagesFilterPhotoVideoConstructor();
        }

        public static MessagesFilter inputMessagesFilterPhotoVideoDocuments()
        {
            return new InputMessagesFilterPhotoVideoDocumentsConstructor();
        }

        public static MessagesFilter inputMessagesFilterDocument()
        {
            return new InputMessagesFilterDocumentConstructor();
        }

        public static MessagesFilter inputMessagesFilterAudio()
        {
            return new InputMessagesFilterAudioConstructor();
        }

        public static MessagesFilter inputMessagesFilterAudioDocuments()
        {
            return new InputMessagesFilterAudioDocumentsConstructor();
        }

        public static MessagesFilter inputMessagesFilterUrl()
        {
            return new InputMessagesFilterUrlConstructor();
        }

        public static Update updateNewMessage(Message message, int pts, int pts_count)
        {
            return new UpdateNewMessageConstructor(message, pts, pts_count);
        }

        public static Update updateMessageID(int id, long random_id)
        {
            return new UpdateMessageIDConstructor(id, random_id);
        }

        public static Update updateDeleteMessages(List<int> messages, int pts, int pts_count)
        {
            return new UpdateDeleteMessagesConstructor(messages, pts, pts_count);
        }

        public static Update updateUserTyping(int user_id, SendMessageAction action)
        {
            return new UpdateUserTypingConstructor(user_id, action);
        }

        public static Update updateChatUserTyping(int chat_id, int user_id, SendMessageAction action)
        {
            return new UpdateChatUserTypingConstructor(chat_id, user_id, action);
        }

        public static Update updateChatParticipants(ChatParticipants participants)
        {
            return new UpdateChatParticipantsConstructor(participants);
        }

        public static Update updateUserStatus(int user_id, UserStatus status)
        {
            return new UpdateUserStatusConstructor(user_id, status);
        }

        public static Update updateUserName(int user_id, string first_name, string last_name, string username)
        {
            return new UpdateUserNameConstructor(user_id, first_name, last_name, username);
        }

        public static Update updateUserPhoto(int user_id, int date, UserProfilePhoto photo, bool previous)
        {
            return new UpdateUserPhotoConstructor(user_id, date, photo, previous);
        }

        public static Update updateContactRegistered(int user_id, int date)
        {
            return new UpdateContactRegisteredConstructor(user_id, date);
        }

        public static Update updateContactLink(int user_id, ContactLink my_link, ContactLink foreign_link)
        {
            return new UpdateContactLinkConstructor(user_id, my_link, foreign_link);
        }

        public static Update updateNewAuthorization(long auth_key_id, int date, string device, string location)
        {
            return new UpdateNewAuthorizationConstructor(auth_key_id, date, device, location);
        }

        public static Update updateNewEncryptedMessage(EncryptedMessage message, int qts)
        {
            return new UpdateNewEncryptedMessageConstructor(message, qts);
        }

        public static Update updateEncryptedChatTyping(int chat_id)
        {
            return new UpdateEncryptedChatTypingConstructor(chat_id);
        }

        public static Update updateEncryption(EncryptedChat chat, int date)
        {
            return new UpdateEncryptionConstructor(chat, date);
        }

        public static Update updateEncryptedMessagesRead(int chat_id, int max_date, int date)
        {
            return new UpdateEncryptedMessagesReadConstructor(chat_id, max_date, date);
        }

        public static Update updateChatParticipantAdd(int chat_id, int user_id, int inviter_id, int date, int version)
        {
            return new UpdateChatParticipantAddConstructor(chat_id, user_id, inviter_id, date, version);
        }

        public static Update updateChatParticipantDelete(int chat_id, int user_id, int version)
        {
            return new UpdateChatParticipantDeleteConstructor(chat_id, user_id, version);
        }

        public static Update updateDcOptions(List<DcOption> dc_options)
        {
            return new UpdateDcOptionsConstructor(dc_options);
        }

        public static Update updateUserBlocked(int user_id, bool blocked)
        {
            return new UpdateUserBlockedConstructor(user_id, blocked);
        }

        public static Update updateNotifySettings(NotifyPeer peer, PeerNotifySettings notify_settings)
        {
            return new UpdateNotifySettingsConstructor(peer, notify_settings);
        }

        public static Update updateServiceNotification(string type, string message, MessageMedia media, bool popup)
        {
            return new UpdateServiceNotificationConstructor(type, message, media, popup);
        }

        public static Update updatePrivacy(PrivacyKey key, List<PrivacyRule> rules)
        {
            return new UpdatePrivacyConstructor(key, rules);
        }

        public static Update updateUserPhone(int user_id, string phone)
        {
            return new UpdateUserPhoneConstructor(user_id, phone);
        }

        public static Update updateReadHistoryInbox(Peer peer, int max_id, int pts, int pts_count)
        {
            return new UpdateReadHistoryInboxConstructor(peer, max_id, pts, pts_count);
        }

        public static Update updateReadHistoryOutbox(Peer peer, int max_id, int pts, int pts_count)
        {
            return new UpdateReadHistoryOutboxConstructor(peer, max_id, pts, pts_count);
        }

        public static Update updateWebPage(WebPage webpage, int pts, int pts_count)
        {
            return new UpdateWebPageConstructor(webpage, pts, pts_count);
        }

        public static Update updateReadMessagesContents(List<int> messages, int pts, int pts_count)
        {
            return new UpdateReadMessagesContentsConstructor(messages, pts, pts_count);
        }

        public static Update updateChannelTooLong(int channel_id)
        {
            return new UpdateChannelTooLongConstructor(channel_id);
        }

        public static Update updateChannel(int channel_id)
        {
            return new UpdateChannelConstructor(channel_id);
        }

        public static Update updateChannelGroup(int channel_id, MessageGroup group)
        {
            return new UpdateChannelGroupConstructor(channel_id, group);
        }

        public static Update updateNewChannelMessage(Message message, int pts, int pts_count)
        {
            return new UpdateNewChannelMessageConstructor(message, pts, pts_count);
        }

        public static Update updateReadChannelInbox(int channel_id, int max_id)
        {
            return new UpdateReadChannelInboxConstructor(channel_id, max_id);
        }

        public static Update updateDeleteChannelMessages(int channel_id, List<int> messages, int pts, int pts_count)
        {
            return new UpdateDeleteChannelMessagesConstructor(channel_id, messages, pts, pts_count);
        }

        public static Update updateChannelMessageViews(int channel_id, int id, int views)
        {
            return new UpdateChannelMessageViewsConstructor(channel_id, id, views);
        }

        public static updates_State updates_state(int pts, int qts, int date, int seq, int unread_count)
        {
            return new Updates_stateConstructor(pts, qts, date, seq, unread_count);
        }

        public static updates_Difference updates_differenceEmpty(int date, int seq)
        {
            return new Updates_differenceEmptyConstructor(date, seq);
        }

        public static updates_Difference updates_difference(List<Message> new_messages, List<EncryptedMessage> new_encrypted_messages, List<Update> other_updates, List<Chat> chats, List<User> users, updates_State state)
        {
            return new Updates_differenceConstructor(new_messages, new_encrypted_messages, other_updates, chats, users, state);
        }

        public static updates_Difference updates_differenceSlice(List<Message> new_messages, List<EncryptedMessage> new_encrypted_messages, List<Update> other_updates, List<Chat> chats, List<User> users, updates_State intermediate_state)
        {
            return new Updates_differenceSliceConstructor(new_messages, new_encrypted_messages, other_updates, chats, users, intermediate_state);
        }

        public static Updates updatesTooLong()
        {
            return new UpdatesTooLongConstructor();
        }

        public static Updates updateShortMessage(int flags, int id, int user_id, string message, int pts, int pts_count, int date, Peer fwd_from_id, int? fwd_date, int? reply_to_msg_id, List<MessageEntity> entities)
        {
            return new UpdateShortMessageConstructor(flags, id, user_id, message, pts, pts_count, date, fwd_from_id, fwd_date, reply_to_msg_id, entities);
        }

        public static Updates updateShortChatMessage(int flags, int id, int from_id, int chat_id, string message, int pts, int pts_count, int date, Peer fwd_from_id, int? fwd_date, int? reply_to_msg_id, List<MessageEntity> entities)
        {
            return new UpdateShortChatMessageConstructor(flags, id, from_id, chat_id, message, pts, pts_count, date, fwd_from_id, fwd_date, reply_to_msg_id, entities);
        }

        public static Updates updateShort(Update update, int date)
        {
            return new UpdateShortConstructor(update, date);
        }

        public static Updates updatesCombined(List<Update> updates, List<User> users, List<Chat> chats, int date, int seq_start, int seq)
        {
            return new UpdatesCombinedConstructor(updates, users, chats, date, seq_start, seq);
        }

        public static Updates updates(List<Update> updates, List<User> users, List<Chat> chats, int date, int seq)
        {
            return new UpdatesConstructor(updates, users, chats, date, seq);
        }

        public static Updates updateShortSentMessage(int flags, int id, int pts, int pts_count, int date, MessageMedia media, List<MessageEntity> entities)
        {
            return new UpdateShortSentMessageConstructor(flags, id, pts, pts_count, date, media, entities);
        }

        public static photos_Photos photos_photos(List<Photo> photos, List<User> users)
        {
            return new Photos_photosConstructor(photos, users);
        }

        public static photos_Photos photos_photosSlice(int count, List<Photo> photos, List<User> users)
        {
            return new Photos_photosSliceConstructor(count, photos, users);
        }

        public static photos_Photo photos_photo(Photo photo, List<User> users)
        {
            return new Photos_photoConstructor(photo, users);
        }

        public static upload_File upload_file(storage_FileType type, int mtime, byte[] bytes)
        {
            return new Upload_fileConstructor(type, mtime, bytes);
        }

        public static DcOption dcOption(int flags, int id, string ip_address, int port)
        {
            return new DcOptionConstructor(flags, id, ip_address, port);
        }

        public static Config config(int date, int expires, bool test_mode, int this_dc, List<DcOption> dc_options, int chat_size_max, int broadcast_size_max, int forwarded_count_max, int online_update_period_ms, int offline_blur_timeout_ms, int offline_idle_timeout_ms, int online_cloud_timeout_ms, int notify_cloud_delay_ms, int notify_default_delay_ms, int chat_big_size, int push_chat_period_ms, int push_chat_limit, List<DisabledFeature> disabled_features)
        {
            return new ConfigConstructor(date, expires, test_mode, this_dc, dc_options, chat_size_max, broadcast_size_max, forwarded_count_max, online_update_period_ms, offline_blur_timeout_ms, offline_idle_timeout_ms, online_cloud_timeout_ms, notify_cloud_delay_ms, notify_default_delay_ms, chat_big_size, push_chat_period_ms, push_chat_limit, disabled_features);
        }

        public static NearestDc nearestDc(string country, int this_dc, int nearest_dc)
        {
            return new NearestDcConstructor(country, this_dc, nearest_dc);
        }

        public static help_AppUpdate help_appUpdate(int id, bool critical, string url, string text)
        {
            return new Help_appUpdateConstructor(id, critical, url, text);
        }

        public static help_AppUpdate help_noAppUpdate()
        {
            return new Help_noAppUpdateConstructor();
        }

        public static help_InviteText help_inviteText(string message)
        {
            return new Help_inviteTextConstructor(message);
        }

        public static EncryptedChat encryptedChatEmpty(int id)
        {
            return new EncryptedChatEmptyConstructor(id);
        }

        public static EncryptedChat encryptedChatWaiting(int id, long access_hash, int date, int admin_id, int participant_id)
        {
            return new EncryptedChatWaitingConstructor(id, access_hash, date, admin_id, participant_id);
        }

        public static EncryptedChat encryptedChatRequested(int id, long access_hash, int date, int admin_id, int participant_id, byte[] g_a)
        {
            return new EncryptedChatRequestedConstructor(id, access_hash, date, admin_id, participant_id, g_a);
        }

        public static EncryptedChat encryptedChat(int id, long access_hash, int date, int admin_id, int participant_id, byte[] g_a_or_b, long key_fingerprint)
        {
            return new EncryptedChatConstructor(id, access_hash, date, admin_id, participant_id, g_a_or_b, key_fingerprint);
        }

        public static EncryptedChat encryptedChatDiscarded(int id)
        {
            return new EncryptedChatDiscardedConstructor(id);
        }

        public static InputEncryptedChat inputEncryptedChat(int chat_id, long access_hash)
        {
            return new InputEncryptedChatConstructor(chat_id, access_hash);
        }

        public static EncryptedFile encryptedFileEmpty()
        {
            return new EncryptedFileEmptyConstructor();
        }

        public static EncryptedFile encryptedFile(long id, long access_hash, int size, int dc_id, int key_fingerprint)
        {
            return new EncryptedFileConstructor(id, access_hash, size, dc_id, key_fingerprint);
        }

        public static InputEncryptedFile inputEncryptedFileEmpty()
        {
            return new InputEncryptedFileEmptyConstructor();
        }

        public static InputEncryptedFile inputEncryptedFileUploaded(long id, int parts, string md5_checksum, int key_fingerprint)
        {
            return new InputEncryptedFileUploadedConstructor(id, parts, md5_checksum, key_fingerprint);
        }

        public static InputEncryptedFile inputEncryptedFile(long id, long access_hash)
        {
            return new InputEncryptedFileConstructor(id, access_hash);
        }

        public static InputEncryptedFile inputEncryptedFileBigUploaded(long id, int parts, int key_fingerprint)
        {
            return new InputEncryptedFileBigUploadedConstructor(id, parts, key_fingerprint);
        }

        public static EncryptedMessage encryptedMessage(long random_id, int chat_id, int date, byte[] bytes, EncryptedFile file)
        {
            return new EncryptedMessageConstructor(random_id, chat_id, date, bytes, file);
        }

        public static EncryptedMessage encryptedMessageService(long random_id, int chat_id, int date, byte[] bytes)
        {
            return new EncryptedMessageServiceConstructor(random_id, chat_id, date, bytes);
        }

        public static messages_DhConfig messages_dhConfigNotModified(byte[] random)
        {
            return new Messages_dhConfigNotModifiedConstructor(random);
        }

        public static messages_DhConfig messages_dhConfig(int g, byte[] p, int version, byte[] random)
        {
            return new Messages_dhConfigConstructor(g, p, version, random);
        }

        public static messages_SentEncryptedMessage messages_sentEncryptedMessage(int date)
        {
            return new Messages_sentEncryptedMessageConstructor(date);
        }

        public static messages_SentEncryptedMessage messages_sentEncryptedFile(int date, EncryptedFile file)
        {
            return new Messages_sentEncryptedFileConstructor(date, file);
        }

        public static InputAudio inputAudioEmpty()
        {
            return new InputAudioEmptyConstructor();
        }

        public static InputAudio inputAudio(long id, long access_hash)
        {
            return new InputAudioConstructor(id, access_hash);
        }

        public static InputDocument inputDocumentEmpty()
        {
            return new InputDocumentEmptyConstructor();
        }

        public static InputDocument inputDocument(long id, long access_hash)
        {
            return new InputDocumentConstructor(id, access_hash);
        }

        public static Audio audioEmpty(long id)
        {
            return new AudioEmptyConstructor(id);
        }

        public static Audio audio(long id, long access_hash, int date, int duration, string mime_type, int size, int dc_id)
        {
            return new AudioConstructor(id, access_hash, date, duration, mime_type, size, dc_id);
        }

        public static Document documentEmpty(long id)
        {
            return new DocumentEmptyConstructor(id);
        }

        public static Document document(long id, long access_hash, int date, string mime_type, int size, PhotoSize thumb, int dc_id, List<DocumentAttribute> attributes)
        {
            return new DocumentConstructor(id, access_hash, date, mime_type, size, thumb, dc_id, attributes);
        }

        public static help_Support help_support(string phone_number, User user)
        {
            return new Help_supportConstructor(phone_number, user);
        }

        public static NotifyPeer notifyPeer(Peer peer)
        {
            return new NotifyPeerConstructor(peer);
        }

        public static NotifyPeer notifyUsers()
        {
            return new NotifyUsersConstructor();
        }

        public static NotifyPeer notifyChats()
        {
            return new NotifyChatsConstructor();
        }

        public static NotifyPeer notifyAll()
        {
            return new NotifyAllConstructor();
        }

        public static SendMessageAction sendMessageTypingAction()
        {
            return new SendMessageTypingActionConstructor();
        }

        public static SendMessageAction sendMessageCancelAction()
        {
            return new SendMessageCancelActionConstructor();
        }

        public static SendMessageAction sendMessageRecordVideoAction()
        {
            return new SendMessageRecordVideoActionConstructor();
        }

        public static SendMessageAction sendMessageUploadVideoAction(int progress)
        {
            return new SendMessageUploadVideoActionConstructor(progress);
        }

        public static SendMessageAction sendMessageRecordAudioAction()
        {
            return new SendMessageRecordAudioActionConstructor();
        }

        public static SendMessageAction sendMessageUploadAudioAction(int progress)
        {
            return new SendMessageUploadAudioActionConstructor(progress);
        }

        public static SendMessageAction sendMessageUploadPhotoAction(int progress)
        {
            return new SendMessageUploadPhotoActionConstructor(progress);
        }

        public static SendMessageAction sendMessageUploadDocumentAction(int progress)
        {
            return new SendMessageUploadDocumentActionConstructor(progress);
        }

        public static SendMessageAction sendMessageGeoLocationAction()
        {
            return new SendMessageGeoLocationActionConstructor();
        }

        public static SendMessageAction sendMessageChooseContactAction()
        {
            return new SendMessageChooseContactActionConstructor();
        }

        public static contacts_Found contacts_found(List<Peer> results, List<Chat> chats, List<User> users)
        {
            return new Contacts_foundConstructor(results, chats, users);
        }

        public static InputPrivacyKey inputPrivacyKeyStatusTimestamp()
        {
            return new InputPrivacyKeyStatusTimestampConstructor();
        }

        public static PrivacyKey privacyKeyStatusTimestamp()
        {
            return new PrivacyKeyStatusTimestampConstructor();
        }

        public static InputPrivacyRule inputPrivacyValueAllowContacts()
        {
            return new InputPrivacyValueAllowContactsConstructor();
        }

        public static InputPrivacyRule inputPrivacyValueAllowAll()
        {
            return new InputPrivacyValueAllowAllConstructor();
        }

        public static InputPrivacyRule inputPrivacyValueAllowUsers(List<InputUser> users)
        {
            return new InputPrivacyValueAllowUsersConstructor(users);
        }

        public static InputPrivacyRule inputPrivacyValueDisallowContacts()
        {
            return new InputPrivacyValueDisallowContactsConstructor();
        }

        public static InputPrivacyRule inputPrivacyValueDisallowAll()
        {
            return new InputPrivacyValueDisallowAllConstructor();
        }

        public static InputPrivacyRule inputPrivacyValueDisallowUsers(List<InputUser> users)
        {
            return new InputPrivacyValueDisallowUsersConstructor(users);
        }

        public static PrivacyRule privacyValueAllowContacts()
        {
            return new PrivacyValueAllowContactsConstructor();
        }

        public static PrivacyRule privacyValueAllowAll()
        {
            return new PrivacyValueAllowAllConstructor();
        }

        public static PrivacyRule privacyValueAllowUsers(List<int> users)
        {
            return new PrivacyValueAllowUsersConstructor(users);
        }

        public static PrivacyRule privacyValueDisallowContacts()
        {
            return new PrivacyValueDisallowContactsConstructor();
        }

        public static PrivacyRule privacyValueDisallowAll()
        {
            return new PrivacyValueDisallowAllConstructor();
        }

        public static PrivacyRule privacyValueDisallowUsers(List<int> users)
        {
            return new PrivacyValueDisallowUsersConstructor(users);
        }

        public static account_PrivacyRules account_privacyRules(List<PrivacyRule> rules, List<User> users)
        {
            return new Account_privacyRulesConstructor(rules, users);
        }

        public static AccountDaysTTL accountDaysTTL(int days)
        {
            return new AccountDaysTTLConstructor(days);
        }

        public static account_SentChangePhoneCode account_sentChangePhoneCode(string phone_code_hash, int send_call_timeout)
        {
            return new Account_sentChangePhoneCodeConstructor(phone_code_hash, send_call_timeout);
        }

        public static DocumentAttribute documentAttributeImageSize(int w, int h)
        {
            return new DocumentAttributeImageSizeConstructor(w, h);
        }

        public static DocumentAttribute documentAttributeAnimated()
        {
            return new DocumentAttributeAnimatedConstructor();
        }

        public static DocumentAttribute documentAttributeSticker(string alt, InputStickerSet stickerset)
        {
            return new DocumentAttributeStickerConstructor(alt, stickerset);
        }

        public static DocumentAttribute documentAttributeVideo(int duration, int w, int h)
        {
            return new DocumentAttributeVideoConstructor(duration, w, h);
        }

        public static DocumentAttribute documentAttributeAudio(int duration, string title, string performer)
        {
            return new DocumentAttributeAudioConstructor(duration, title, performer);
        }

        public static DocumentAttribute documentAttributeFilename(string file_name)
        {
            return new DocumentAttributeFilenameConstructor(file_name);
        }

        public static messages_Stickers messages_stickersNotModified()
        {
            return new Messages_stickersNotModifiedConstructor();
        }

        public static messages_Stickers messages_stickers(string hash, List<Document> stickers)
        {
            return new Messages_stickersConstructor(hash, stickers);
        }

        public static StickerPack stickerPack(string emoticon, List<long> documents)
        {
            return new StickerPackConstructor(emoticon, documents);
        }

        public static messages_AllStickers messages_allStickersNotModified()
        {
            return new Messages_allStickersNotModifiedConstructor();
        }

        public static messages_AllStickers messages_allStickers(string hash, List<StickerSet> sets)
        {
            return new Messages_allStickersConstructor(hash, sets);
        }

        public static DisabledFeature disabledFeature(string feature, string description)
        {
            return new DisabledFeatureConstructor(feature, description);
        }

        public static messages_AffectedMessages messages_affectedMessages(int pts, int pts_count)
        {
            return new Messages_affectedMessagesConstructor(pts, pts_count);
        }

        public static ContactLink contactLinkUnknown()
        {
            return new ContactLinkUnknownConstructor();
        }

        public static ContactLink contactLinkNone()
        {
            return new ContactLinkNoneConstructor();
        }

        public static ContactLink contactLinkHasPhone()
        {
            return new ContactLinkHasPhoneConstructor();
        }

        public static ContactLink contactLinkContact()
        {
            return new ContactLinkContactConstructor();
        }

        public static WebPage webPageEmpty(long id)
        {
            return new WebPageEmptyConstructor(id);
        }

        public static WebPage webPagePending(long id, int date)
        {
            return new WebPagePendingConstructor(id, date);
        }

        public static WebPage webPage(int flags, long id, string url, string display_url, string type, string site_name, string title, string description, Photo photo, string embed_url, string embed_type, int? embed_width, int? embed_height, int? duration, string author, Document document)
        {
            return new WebPageConstructor(flags, id, url, display_url, type, site_name, title, description, photo, embed_url, embed_type, embed_width, embed_height, duration, author, document);
        }

        public static Authorization authorization(long hash, int flags, string device_model, string platform, string system_version, int api_id, string app_name, string app_version, int date_created, int date_active, string ip, string country, string region)
        {
            return new AuthorizationConstructor(hash, flags, device_model, platform, system_version, api_id, app_name, app_version, date_created, date_active, ip, country, region);
        }

        public static account_Authorizations account_authorizations(List<Authorization> authorizations)
        {
            return new Account_authorizationsConstructor(authorizations);
        }

        public static account_Password account_noPassword(byte[] new_salt, string email_unconfirmed_pattern)
        {
            return new Account_noPasswordConstructor(new_salt, email_unconfirmed_pattern);
        }

        public static account_Password account_password(byte[] current_salt, byte[] new_salt, string hint, bool has_recovery, string email_unconfirmed_pattern)
        {
            return new Account_passwordConstructor(current_salt, new_salt, hint, has_recovery, email_unconfirmed_pattern);
        }

        public static account_PasswordSettings account_passwordSettings(string email)
        {
            return new Account_passwordSettingsConstructor(email);
        }

        public static account_PasswordInputSettings account_passwordInputSettings(int flags, byte[] new_salt, byte[] new_password_hash, string hint, string email)
        {
            return new Account_passwordInputSettingsConstructor(flags, new_salt, new_password_hash, hint, email);
        }

        public static auth_PasswordRecovery auth_passwordRecovery(string email_pattern)
        {
            return new Auth_passwordRecoveryConstructor(email_pattern);
        }

        public static ReceivedNotifyMessage receivedNotifyMessage(int id, int flags)
        {
            return new ReceivedNotifyMessageConstructor(id, flags);
        }

        public static ExportedChatInvite chatInviteEmpty()
        {
            return new ChatInviteEmptyConstructor();
        }

        public static ExportedChatInvite chatInviteExported(string link)
        {
            return new ChatInviteExportedConstructor(link);
        }

        public static ChatInvite chatInviteAlready(Chat chat)
        {
            return new ChatInviteAlreadyConstructor(chat);
        }

        public static ChatInvite chatInvite(int flags, string title)
        {
            return new ChatInviteConstructor(flags, title);
        }

        public static InputStickerSet inputStickerSetEmpty()
        {
            return new InputStickerSetEmptyConstructor();
        }

        public static InputStickerSet inputStickerSetID(long id, long access_hash)
        {
            return new InputStickerSetIDConstructor(id, access_hash);
        }

        public static InputStickerSet inputStickerSetShortName(string short_name)
        {
            return new InputStickerSetShortNameConstructor(short_name);
        }

        public static StickerSet stickerSet(int flags, long id, long access_hash, string title, string short_name, int count, int hash)
        {
            return new StickerSetConstructor(flags, id, access_hash, title, short_name, count, hash);
        }

        public static messages_StickerSet messages_stickerSet(StickerSet set, List<StickerPack> packs, List<Document> documents)
        {
            return new Messages_stickerSetConstructor(set, packs, documents);
        }

        public static BotCommand botCommand(string command, string description)
        {
            return new BotCommandConstructor(command, description);
        }

        public static BotInfo botInfoEmpty()
        {
            return new BotInfoEmptyConstructor();
        }

        public static BotInfo botInfo(int user_id, int version, string share_text, string description, List<BotCommand> commands)
        {
            return new BotInfoConstructor(user_id, version, share_text, description, commands);
        }

        public static KeyboardButton keyboardButton(string text)
        {
            return new KeyboardButtonConstructor(text);
        }

        public static KeyboardButtonRow keyboardButtonRow(List<KeyboardButton> buttons)
        {
            return new KeyboardButtonRowConstructor(buttons);
        }

        public static ReplyMarkup replyKeyboardHide(int flags)
        {
            return new ReplyKeyboardHideConstructor(flags);
        }

        public static ReplyMarkup replyKeyboardForceReply(int flags)
        {
            return new ReplyKeyboardForceReplyConstructor(flags);
        }

        public static ReplyMarkup replyKeyboardMarkup(int flags, List<KeyboardButtonRow> rows)
        {
            return new ReplyKeyboardMarkupConstructor(flags, rows);
        }

        public static help_AppChangelog help_appChangelogEmpty()
        {
            return new Help_appChangelogEmptyConstructor();
        }

        public static help_AppChangelog help_appChangelog(string text)
        {
            return new Help_appChangelogConstructor(text);
        }

        public static MessageEntity messageEntityUnknown(int offset, int length)
        {
            return new MessageEntityUnknownConstructor(offset, length);
        }

        public static MessageEntity messageEntityMention(int offset, int length)
        {
            return new MessageEntityMentionConstructor(offset, length);
        }

        public static MessageEntity messageEntityHashtag(int offset, int length)
        {
            return new MessageEntityHashtagConstructor(offset, length);
        }

        public static MessageEntity messageEntityBotCommand(int offset, int length)
        {
            return new MessageEntityBotCommandConstructor(offset, length);
        }

        public static MessageEntity messageEntityUrl(int offset, int length)
        {
            return new MessageEntityUrlConstructor(offset, length);
        }

        public static MessageEntity messageEntityEmail(int offset, int length)
        {
            return new MessageEntityEmailConstructor(offset, length);
        }

        public static MessageEntity messageEntityBold(int offset, int length)
        {
            return new MessageEntityBoldConstructor(offset, length);
        }

        public static MessageEntity messageEntityItalic(int offset, int length)
        {
            return new MessageEntityItalicConstructor(offset, length);
        }

        public static MessageEntity messageEntityCode(int offset, int length)
        {
            return new MessageEntityCodeConstructor(offset, length);
        }

        public static MessageEntity messageEntityPre(int offset, int length, string language)
        {
            return new MessageEntityPreConstructor(offset, length, language);
        }

        public static MessageEntity messageEntityTextUrl(int offset, int length, string url)
        {
            return new MessageEntityTextUrlConstructor(offset, length, url);
        }

        public static InputChannel inputChannelEmpty()
        {
            return new InputChannelEmptyConstructor();
        }

        public static InputChannel inputChannel(int channel_id, long access_hash)
        {
            return new InputChannelConstructor(channel_id, access_hash);
        }

        public static contacts_ResolvedPeer contacts_resolvedPeer(Peer peer, List<Chat> chats, List<User> users)
        {
            return new Contacts_resolvedPeerConstructor(peer, chats, users);
        }

        public static MessageRange messageRange(int min_id, int max_id)
        {
            return new MessageRangeConstructor(min_id, max_id);
        }

        public static MessageGroup messageGroup(int min_id, int max_id, int count, int date)
        {
            return new MessageGroupConstructor(min_id, max_id, count, date);
        }

        public static updates_ChannelDifference updates_channelDifferenceEmpty(int flags, int pts, int? timeout)
        {
            return new Updates_channelDifferenceEmptyConstructor(flags, pts, timeout);
        }

        public static updates_ChannelDifference updates_channelDifferenceTooLong(int flags, int pts, int? timeout, int top_message, int top_important_message, int read_inbox_max_id, int unread_count, int unread_important_count, List<Message> messages, List<Chat> chats, List<User> users)
        {
            return new Updates_channelDifferenceTooLongConstructor(flags, pts, timeout, top_message, top_important_message, read_inbox_max_id, unread_count, unread_important_count, messages, chats, users);
        }

        public static updates_ChannelDifference updates_channelDifference(int flags, int pts, int? timeout, List<Message> new_messages, List<Update> other_updates, List<Chat> chats, List<User> users)
        {
            return new Updates_channelDifferenceConstructor(flags, pts, timeout, new_messages, other_updates, chats, users);
        }

        public static ChannelMessagesFilter channelMessagesFilterEmpty()
        {
            return new ChannelMessagesFilterEmptyConstructor();
        }

        public static ChannelMessagesFilter channelMessagesFilter(int flags, List<MessageRange> ranges)
        {
            return new ChannelMessagesFilterConstructor(flags, ranges);
        }

        public static ChannelMessagesFilter channelMessagesFilterCollapsed()
        {
            return new ChannelMessagesFilterCollapsedConstructor();
        }

        public static ChannelParticipant channelParticipant(int user_id, int date)
        {
            return new ChannelParticipantConstructor(user_id, date);
        }

        public static ChannelParticipant channelParticipantSelf(int user_id, int inviter_id, int date)
        {
            return new ChannelParticipantSelfConstructor(user_id, inviter_id, date);
        }

        public static ChannelParticipant channelParticipantModerator(int user_id, int inviter_id, int date)
        {
            return new ChannelParticipantModeratorConstructor(user_id, inviter_id, date);
        }

        public static ChannelParticipant channelParticipantEditor(int user_id, int inviter_id, int date)
        {
            return new ChannelParticipantEditorConstructor(user_id, inviter_id, date);
        }

        public static ChannelParticipant channelParticipantKicked(int user_id, int kicked_by, int date)
        {
            return new ChannelParticipantKickedConstructor(user_id, kicked_by, date);
        }

        public static ChannelParticipant channelParticipantCreator(int user_id)
        {
            return new ChannelParticipantCreatorConstructor(user_id);
        }

        public static ChannelParticipantsFilter channelParticipantsRecent()
        {
            return new ChannelParticipantsRecentConstructor();
        }

        public static ChannelParticipantsFilter channelParticipantsAdmins()
        {
            return new ChannelParticipantsAdminsConstructor();
        }

        public static ChannelParticipantsFilter channelParticipantsKicked()
        {
            return new ChannelParticipantsKickedConstructor();
        }

        public static ChannelParticipantRole channelRoleEmpty()
        {
            return new ChannelRoleEmptyConstructor();
        }

        public static ChannelParticipantRole channelRoleModerator()
        {
            return new ChannelRoleModeratorConstructor();
        }

        public static ChannelParticipantRole channelRoleEditor()
        {
            return new ChannelRoleEditorConstructor();
        }

        public static channels_ChannelParticipants channels_channelParticipants(int count, List<ChannelParticipant> participants, List<User> users)
        {
            return new Channels_channelParticipantsConstructor(count, participants, users);
        }

        public static channels_ChannelParticipant channels_channelParticipant(ChannelParticipant participant, List<User> users)
        {
            return new Channels_channelParticipantConstructor(participant, users);
        }


    }
    // Abstract types
    public abstract class MsgsAck : TLObject { }
    public abstract class BadMsgNotification : TLObject { }
    public abstract class MsgsStateReq : TLObject { }
    public abstract class MsgsStateInfo : TLObject { }
    public abstract class MsgsAllInfo : TLObject { }
    public abstract class MsgDetailedInfo : TLObject { }
    public abstract class MsgResendReq : TLObject { }
    public abstract class RpcError : TLObject { }
    public abstract class RpcDropAnswer : TLObject { }
    public abstract class FutureSalt : TLObject { }
    public abstract class Pong : TLObject { }
    public abstract class DestroySessionRes : TLObject { }
    public abstract class NewSession : TLObject { }
    public abstract class HttpWait : TLObject { }
    public abstract class Error : TLObject { }
    public abstract class Null : TLObject { }
    public abstract class InputPeer : TLObject { }
    public abstract class InputUser : TLObject { }
    public abstract class InputContact : TLObject { }
    public abstract class InputFile : TLObject { }
    public abstract class InputMedia : TLObject { }
    public abstract class InputChatPhoto : TLObject { }
    public abstract class InputGeoPoint : TLObject { }
    public abstract class InputPhoto : TLObject { }
    public abstract class InputVideo : TLObject { }
    public abstract class InputFileLocation : TLObject { }
    public abstract class InputPhotoCrop : TLObject { }
    public abstract class InputAppEvent : TLObject { }
    public abstract class Peer : TLObject { }
    public abstract class storage_FileType : TLObject { }
    public abstract class FileLocation : TLObject { }
    public abstract class User : TLObject { }
    public abstract class UserProfilePhoto : TLObject { }
    public abstract class UserStatus : TLObject { }
    public abstract class Chat : TLObject { }
    public abstract class ChatFull : TLObject { }
    public abstract class ChatParticipant : TLObject { }
    public abstract class ChatParticipants : TLObject { }
    public abstract class ChatPhoto : TLObject { }
    public abstract class Message : TLObject { }
    public abstract class MessageMedia : TLObject { }
    public abstract class MessageAction : TLObject { }
    public abstract class Dialog : TLObject { }
    public abstract class Photo : TLObject { }
    public abstract class PhotoSize : TLObject { }
    public abstract class Video : TLObject { }
    public abstract class GeoPoint : TLObject { }
    public abstract class auth_CheckedPhone : TLObject { }
    public abstract class auth_SentCode : TLObject { }
    public abstract class auth_Authorization : TLObject { }
    public abstract class auth_ExportedAuthorization : TLObject { }
    public abstract class InputNotifyPeer : TLObject { }
    public abstract class InputPeerNotifyEvents : TLObject { }
    public abstract class InputPeerNotifySettings : TLObject { }
    public abstract class PeerNotifyEvents : TLObject { }
    public abstract class PeerNotifySettings : TLObject { }
    public abstract class WallPaper : TLObject { }
    public abstract class UserFull : TLObject { }
    public abstract class Contact : TLObject { }
    public abstract class ImportedContact : TLObject { }
    public abstract class ContactBlocked : TLObject { }
    public abstract class ContactSuggested : TLObject { }
    public abstract class ContactStatus : TLObject { }
    public abstract class contacts_Link : TLObject { }
    public abstract class contacts_Contacts : TLObject { }
    public abstract class contacts_ImportedContacts : TLObject { }
    public abstract class contacts_Blocked : TLObject { }
    public abstract class contacts_Suggested : TLObject { }
    public abstract class messages_Dialogs : TLObject { }
    public abstract class messages_Messages : TLObject { }
    public abstract class messages_Chats : TLObject { }
    public abstract class messages_ChatFull : TLObject { }
    public abstract class messages_AffectedHistory : TLObject { }
    public abstract class MessagesFilter : TLObject { }
    public abstract class Update : TLObject { }
    public abstract class updates_State : TLObject { }
    public abstract class updates_Difference : TLObject { }
    public abstract class Updates : TLObject { }
    public abstract class photos_Photos : TLObject { }
    public abstract class photos_Photo : TLObject { }
    public abstract class upload_File : TLObject { }
    public abstract class DcOption : TLObject { }
    public abstract class Config : TLObject { }
    public abstract class NearestDc : TLObject { }
    public abstract class help_AppUpdate : TLObject { }
    public abstract class help_InviteText : TLObject { }
    public abstract class EncryptedChat : TLObject { }
    public abstract class InputEncryptedChat : TLObject { }
    public abstract class EncryptedFile : TLObject { }
    public abstract class InputEncryptedFile : TLObject { }
    public abstract class EncryptedMessage : TLObject { }
    public abstract class messages_DhConfig : TLObject { }
    public abstract class messages_SentEncryptedMessage : TLObject { }
    public abstract class InputAudio : TLObject { }
    public abstract class InputDocument : TLObject { }
    public abstract class Audio : TLObject { }
    public abstract class Document : TLObject { }
    public abstract class help_Support : TLObject { }
    public abstract class NotifyPeer : TLObject { }
    public abstract class SendMessageAction : TLObject { }
    public abstract class contacts_Found : TLObject { }
    public abstract class InputPrivacyKey : TLObject { }
    public abstract class PrivacyKey : TLObject { }
    public abstract class InputPrivacyRule : TLObject { }
    public abstract class PrivacyRule : TLObject { }
    public abstract class account_PrivacyRules : TLObject { }
    public abstract class AccountDaysTTL : TLObject { }
    public abstract class account_SentChangePhoneCode : TLObject { }
    public abstract class DocumentAttribute : TLObject { }
    public abstract class messages_Stickers : TLObject { }
    public abstract class StickerPack : TLObject { }
    public abstract class messages_AllStickers : TLObject { }
    public abstract class DisabledFeature : TLObject { }
    public abstract class messages_AffectedMessages : TLObject { }
    public abstract class ContactLink : TLObject { }
    public abstract class WebPage : TLObject { }
    public abstract class Authorization : TLObject { }
    public abstract class account_Authorizations : TLObject { }
    public abstract class account_Password : TLObject { }
    public abstract class account_PasswordSettings : TLObject { }
    public abstract class account_PasswordInputSettings : TLObject { }
    public abstract class auth_PasswordRecovery : TLObject { }
    public abstract class ReceivedNotifyMessage : TLObject { }
    public abstract class ExportedChatInvite : TLObject { }
    public abstract class ChatInvite : TLObject { }
    public abstract class InputStickerSet : TLObject { }
    public abstract class StickerSet : TLObject { }
    public abstract class messages_StickerSet : TLObject { }
    public abstract class BotCommand : TLObject { }
    public abstract class BotInfo : TLObject { }
    public abstract class KeyboardButton : TLObject { }
    public abstract class KeyboardButtonRow : TLObject { }
    public abstract class ReplyMarkup : TLObject { }
    public abstract class help_AppChangelog : TLObject { }
    public abstract class MessageEntity : TLObject { }
    public abstract class InputChannel : TLObject { }
    public abstract class contacts_ResolvedPeer : TLObject { }
    public abstract class MessageRange : TLObject { }
    public abstract class MessageGroup : TLObject { }
    public abstract class updates_ChannelDifference : TLObject { }
    public abstract class ChannelMessagesFilter : TLObject { }
    public abstract class ChannelParticipant : TLObject { }
    public abstract class ChannelParticipantsFilter : TLObject { }
    public abstract class ChannelParticipantRole : TLObject { }
    public abstract class channels_ChannelParticipants : TLObject { }
    public abstract class channels_ChannelParticipant : TLObject { }

    //Types implementation
    public class Msgs_ackConstructor : MsgsAck
    {
        public List<long> msg_ids;

        public Msgs_ackConstructor() { }

        public Msgs_ackConstructor(List<long> msg_ids)
        {
            this.msg_ids = msg_ids;
        }

        public override Constructor Constructor
        { get { return Constructor.msgs_ack; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x62d6b459);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(msg_ids.Count);
            foreach (long msg_ids_element in msg_ids)
                writer.Write(msg_ids_element);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int msg_ids_count = reader.ReadInt32();
            msg_ids = new List<long>(msg_ids_count);
            for (int msg_ids_index = 0; msg_ids_index < msg_ids_count; msg_ids_index++)
                msg_ids.Add(reader.ReadInt64());
        }

        public override string ToString()
        {
            return string.Format("(msgs_ack msg_ids:{0})", msg_ids);
        }
    }

    public class Bad_msg_notificationConstructor : BadMsgNotification
    {
        public long bad_msg_id;
        public int bad_msg_seqno;
        public int error_code;

        public Bad_msg_notificationConstructor() { }

        public Bad_msg_notificationConstructor(long bad_msg_id, int bad_msg_seqno, int error_code)
        {
            this.bad_msg_id = bad_msg_id;
            this.bad_msg_seqno = bad_msg_seqno;
            this.error_code = error_code;
        }

        public override Constructor Constructor
        { get { return Constructor.bad_msg_notification; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa7eff811);
            writer.Write(bad_msg_id);
            writer.Write(bad_msg_seqno);
            writer.Write(error_code);
        }

        public override void Read(BinaryReader reader)
        {
            bad_msg_id = reader.ReadInt64();
            bad_msg_seqno = reader.ReadInt32();
            error_code = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(bad_msg_notification bad_msg_id:{0} bad_msg_seqno:{1} error_code:{2})", bad_msg_id, bad_msg_seqno, error_code);
        }
    }

    public class Bad_server_saltConstructor : BadMsgNotification
    {
        public long bad_msg_id;
        public int bad_msg_seqno;
        public int error_code;
        public long new_server_salt;

        public Bad_server_saltConstructor() { }

        public Bad_server_saltConstructor(long bad_msg_id, int bad_msg_seqno, int error_code, long new_server_salt)
        {
            this.bad_msg_id = bad_msg_id;
            this.bad_msg_seqno = bad_msg_seqno;
            this.error_code = error_code;
            this.new_server_salt = new_server_salt;
        }

        public override Constructor Constructor
        { get { return Constructor.bad_server_salt; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xedab447b);
            writer.Write(bad_msg_id);
            writer.Write(bad_msg_seqno);
            writer.Write(error_code);
            writer.Write(new_server_salt);
        }

        public override void Read(BinaryReader reader)
        {
            bad_msg_id = reader.ReadInt64();
            bad_msg_seqno = reader.ReadInt32();
            error_code = reader.ReadInt32();
            new_server_salt = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(bad_server_salt bad_msg_id:{0} bad_msg_seqno:{1} error_code:{2} new_server_salt:{3})", bad_msg_id, bad_msg_seqno, error_code, new_server_salt);
        }
    }

    public class Msgs_state_reqConstructor : MsgsStateReq
    {
        public List<long> msg_ids;

        public Msgs_state_reqConstructor() { }

        public Msgs_state_reqConstructor(List<long> msg_ids)
        {
            this.msg_ids = msg_ids;
        }

        public override Constructor Constructor
        { get { return Constructor.msgs_state_req; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xda69fb52);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(msg_ids.Count);
            foreach (long msg_ids_element in msg_ids)
                writer.Write(msg_ids_element);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int msg_ids_count = reader.ReadInt32();
            msg_ids = new List<long>(msg_ids_count);
            for (int msg_ids_index = 0; msg_ids_index < msg_ids_count; msg_ids_index++)
                msg_ids.Add(reader.ReadInt64());
        }

        public override string ToString()
        {
            return string.Format("(msgs_state_req msg_ids:{0})", msg_ids);
        }
    }

    public class Msgs_state_infoConstructor : MsgsStateInfo
    {
        public long req_msg_id;
        public string info;

        public Msgs_state_infoConstructor() { }

        public Msgs_state_infoConstructor(long req_msg_id, string info)
        {
            this.req_msg_id = req_msg_id;
            this.info = info;
        }

        public override Constructor Constructor
        { get { return Constructor.msgs_state_info; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x04deb57d);
            writer.Write(req_msg_id);
            Serializers.String.Write(writer, info);
        }

        public override void Read(BinaryReader reader)
        {
            req_msg_id = reader.ReadInt64();
            info = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(msgs_state_info req_msg_id:{0} info:{1})", req_msg_id, info);
        }
    }

    public class Msgs_all_infoConstructor : MsgsAllInfo
    {
        public List<long> msg_ids;
        public string info;

        public Msgs_all_infoConstructor() { }

        public Msgs_all_infoConstructor(List<long> msg_ids, string info)
        {
            this.msg_ids = msg_ids;
            this.info = info;
        }

        public override Constructor Constructor
        { get { return Constructor.msgs_all_info; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x8cc0d131);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(msg_ids.Count);
            foreach (long msg_ids_element in msg_ids)
                writer.Write(msg_ids_element);
            Serializers.String.Write(writer, info);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int msg_ids_count = reader.ReadInt32();
            msg_ids = new List<long>(msg_ids_count);
            for (int msg_ids_index = 0; msg_ids_index < msg_ids_count; msg_ids_index++)
                msg_ids.Add(reader.ReadInt64());
            info = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(msgs_all_info msg_ids:{0} info:{1})", msg_ids, info);
        }
    }

    public class Msg_detailed_infoConstructor : MsgDetailedInfo
    {
        public long msg_id;
        public long answer_msg_id;
        public int bytes;
        public int status;

        public Msg_detailed_infoConstructor() { }

        public Msg_detailed_infoConstructor(long msg_id, long answer_msg_id, int bytes, int status)
        {
            this.msg_id = msg_id;
            this.answer_msg_id = answer_msg_id;
            this.bytes = bytes;
            this.status = status;
        }

        public override Constructor Constructor
        { get { return Constructor.msg_detailed_info; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x276d3ec6);
            writer.Write(msg_id);
            writer.Write(answer_msg_id);
            writer.Write(bytes);
            writer.Write(status);
        }

        public override void Read(BinaryReader reader)
        {
            msg_id = reader.ReadInt64();
            answer_msg_id = reader.ReadInt64();
            bytes = reader.ReadInt32();
            status = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(msg_detailed_info msg_id:{0} answer_msg_id:{1} bytes:{2} status:{3})", msg_id, answer_msg_id, bytes, status);
        }
    }

    public class Msg_new_detailed_infoConstructor : MsgDetailedInfo
    {
        public long answer_msg_id;
        public int bytes;
        public int status;

        public Msg_new_detailed_infoConstructor() { }

        public Msg_new_detailed_infoConstructor(long answer_msg_id, int bytes, int status)
        {
            this.answer_msg_id = answer_msg_id;
            this.bytes = bytes;
            this.status = status;
        }

        public override Constructor Constructor
        { get { return Constructor.msg_new_detailed_info; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x809db6df);
            writer.Write(answer_msg_id);
            writer.Write(bytes);
            writer.Write(status);
        }

        public override void Read(BinaryReader reader)
        {
            answer_msg_id = reader.ReadInt64();
            bytes = reader.ReadInt32();
            status = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(msg_new_detailed_info answer_msg_id:{0} bytes:{1} status:{2})", answer_msg_id, bytes, status);
        }
    }

    public class Msg_resend_reqConstructor : MsgResendReq
    {
        public List<long> msg_ids;

        public Msg_resend_reqConstructor() { }

        public Msg_resend_reqConstructor(List<long> msg_ids)
        {
            this.msg_ids = msg_ids;
        }

        public override Constructor Constructor
        { get { return Constructor.msg_resend_req; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7d861a08);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(msg_ids.Count);
            foreach (long msg_ids_element in msg_ids)
                writer.Write(msg_ids_element);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int msg_ids_count = reader.ReadInt32();
            msg_ids = new List<long>(msg_ids_count);
            for (int msg_ids_index = 0; msg_ids_index < msg_ids_count; msg_ids_index++)
                msg_ids.Add(reader.ReadInt64());
        }

        public override string ToString()
        {
            return string.Format("(msg_resend_req msg_ids:{0})", msg_ids);
        }
    }

    public class Rpc_errorConstructor : RpcError
    {
        public int error_code;
        public string error_message;

        public Rpc_errorConstructor() { }

        public Rpc_errorConstructor(int error_code, string error_message)
        {
            this.error_code = error_code;
            this.error_message = error_message;
        }

        public override Constructor Constructor
        { get { return Constructor.rpc_error; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2144ca19);
            writer.Write(error_code);
            Serializers.String.Write(writer, error_message);
        }

        public override void Read(BinaryReader reader)
        {
            error_code = reader.ReadInt32();
            error_message = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(rpc_error error_code:{0} error_message:{1})", error_code, error_message);
        }
    }

    public class Rpc_answer_unknownConstructor : RpcDropAnswer
    {
        public Rpc_answer_unknownConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.rpc_answer_unknown; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5e2ad36e);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(rpc_answer_unknown)");
        }
    }

    public class Rpc_answer_dropped_runningConstructor : RpcDropAnswer
    {
        public Rpc_answer_dropped_runningConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.rpc_answer_dropped_running; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xcd78e586);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(rpc_answer_dropped_running)");
        }
    }

    public class Rpc_answer_droppedConstructor : RpcDropAnswer
    {
        public long msg_id;
        public int seq_no;
        public int bytes;

        public Rpc_answer_droppedConstructor() { }

        public Rpc_answer_droppedConstructor(long msg_id, int seq_no, int bytes)
        {
            this.msg_id = msg_id;
            this.seq_no = seq_no;
            this.bytes = bytes;
        }

        public override Constructor Constructor
        { get { return Constructor.rpc_answer_dropped; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa43ad8b7);
            writer.Write(msg_id);
            writer.Write(seq_no);
            writer.Write(bytes);
        }

        public override void Read(BinaryReader reader)
        {
            msg_id = reader.ReadInt64();
            seq_no = reader.ReadInt32();
            bytes = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(rpc_answer_dropped msg_id:{0} seq_no:{1} bytes:{2})", msg_id, seq_no, bytes);
        }
    }

    public class Future_saltConstructor : FutureSalt
    {
        public int valid_since;
        public int valid_until;
        public long salt;

        public Future_saltConstructor() { }

        public Future_saltConstructor(int valid_since, int valid_until, long salt)
        {
            this.valid_since = valid_since;
            this.valid_until = valid_until;
            this.salt = salt;
        }

        public override Constructor Constructor
        { get { return Constructor.future_salt; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x0949d9dc);
            writer.Write(valid_since);
            writer.Write(valid_until);
            writer.Write(salt);
        }

        public override void Read(BinaryReader reader)
        {
            valid_since = reader.ReadInt32();
            valid_until = reader.ReadInt32();
            salt = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(future_salt valid_since:{0} valid_until:{1} salt:{2})", valid_since, valid_until, salt);
        }
    }

    public class PongConstructor : Pong
    {
        public long msg_id;
        public long ping_id;

        public PongConstructor() { }

        public PongConstructor(long msg_id, long ping_id)
        {
            this.msg_id = msg_id;
            this.ping_id = ping_id;
        }

        public override Constructor Constructor
        { get { return Constructor.pong; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x347773c5);
            writer.Write(msg_id);
            writer.Write(ping_id);
        }

        public override void Read(BinaryReader reader)
        {
            msg_id = reader.ReadInt64();
            ping_id = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(pong msg_id:{0} ping_id:{1})", msg_id, ping_id);
        }
    }

    public class Destroy_session_okConstructor : DestroySessionRes
    {
        public long session_id;

        public Destroy_session_okConstructor() { }

        public Destroy_session_okConstructor(long session_id)
        {
            this.session_id = session_id;
        }

        public override Constructor Constructor
        { get { return Constructor.destroy_session_ok; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe22045fc);
            writer.Write(session_id);
        }

        public override void Read(BinaryReader reader)
        {
            session_id = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(destroy_session_ok session_id:{0})", session_id);
        }
    }

    public class Destroy_session_noneConstructor : DestroySessionRes
    {
        public long session_id;

        public Destroy_session_noneConstructor() { }

        public Destroy_session_noneConstructor(long session_id)
        {
            this.session_id = session_id;
        }

        public override Constructor Constructor
        { get { return Constructor.destroy_session_none; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x62d350c9);
            writer.Write(session_id);
        }

        public override void Read(BinaryReader reader)
        {
            session_id = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(destroy_session_none session_id:{0})", session_id);
        }
    }

    public class New_session_createdConstructor : NewSession
    {
        public long first_msg_id;
        public long unique_id;
        public long server_salt;

        public New_session_createdConstructor() { }

        public New_session_createdConstructor(long first_msg_id, long unique_id, long server_salt)
        {
            this.first_msg_id = first_msg_id;
            this.unique_id = unique_id;
            this.server_salt = server_salt;
        }

        public override Constructor Constructor
        { get { return Constructor.new_session_created; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9ec20908);
            writer.Write(first_msg_id);
            writer.Write(unique_id);
            writer.Write(server_salt);
        }

        public override void Read(BinaryReader reader)
        {
            first_msg_id = reader.ReadInt64();
            unique_id = reader.ReadInt64();
            server_salt = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(new_session_created first_msg_id:{0} unique_id:{1} server_salt:{2})", first_msg_id, unique_id, server_salt);
        }
    }

    public class Http_waitConstructor : HttpWait
    {
        public int max_delay;
        public int wait_after;
        public int max_wait;

        public Http_waitConstructor() { }

        public Http_waitConstructor(int max_delay, int wait_after, int max_wait)
        {
            this.max_delay = max_delay;
            this.wait_after = wait_after;
            this.max_wait = max_wait;
        }

        public override Constructor Constructor
        { get { return Constructor.http_wait; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9299359f);
            writer.Write(max_delay);
            writer.Write(wait_after);
            writer.Write(max_wait);
        }

        public override void Read(BinaryReader reader)
        {
            max_delay = reader.ReadInt32();
            wait_after = reader.ReadInt32();
            max_wait = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(http_wait max_delay:{0} wait_after:{1} max_wait:{2})", max_delay, wait_after, max_wait);
        }
    }

    public class ErrorConstructor : Error
    {
        public int code;
        public string text;

        public ErrorConstructor() { }

        public ErrorConstructor(int code, string text)
        {
            this.code = code;
            this.text = text;
        }

        public override Constructor Constructor
        { get { return Constructor.error; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc4b9f9bb);
            writer.Write(code);
            Serializers.String.Write(writer, text);
        }

        public override void Read(BinaryReader reader)
        {
            code = reader.ReadInt32();
            text = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(error code:{0} text:{1})", code, text);
        }
    }

    public class @nullConstructor : Null
    {
        public @nullConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.@null; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x56730bcc);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(@null)");
        }
    }

    public class InputPeerEmptyConstructor : InputPeer
    {
        public InputPeerEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputPeerEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7f3b18ea);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputPeerEmpty)");
        }
    }

    public class InputPeerSelfConstructor : InputPeer
    {
        public InputPeerSelfConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputPeerSelf; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7da07ec9);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputPeerSelf)");
        }
    }

    public class InputPeerChatConstructor : InputPeer
    {
        public int chat_id;

        public InputPeerChatConstructor() { }

        public InputPeerChatConstructor(int chat_id)
        {
            this.chat_id = chat_id;
        }

        public override Constructor Constructor
        { get { return Constructor.inputPeerChat; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x179be863);
            writer.Write(chat_id);
        }

        public override void Read(BinaryReader reader)
        {
            chat_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(inputPeerChat chat_id:{0})", chat_id);
        }
    }

    public class InputPeerUserConstructor : InputPeer
    {
        public int user_id;
        public long access_hash;

        public InputPeerUserConstructor() { }

        public InputPeerUserConstructor(int user_id, long access_hash)
        {
            this.user_id = user_id;
            this.access_hash = access_hash;
        }

        public override Constructor Constructor
        { get { return Constructor.inputPeerUser; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7b8e7de6);
            writer.Write(user_id);
            writer.Write(access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(inputPeerUser user_id:{0} access_hash:{1})", user_id, access_hash);
        }
    }

    public class InputPeerChannelConstructor : InputPeer
    {
        public int channel_id;
        public long access_hash;

        public InputPeerChannelConstructor() { }

        public InputPeerChannelConstructor(int channel_id, long access_hash)
        {
            this.channel_id = channel_id;
            this.access_hash = access_hash;
        }

        public override Constructor Constructor
        { get { return Constructor.inputPeerChannel; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x20adaef8);
            writer.Write(channel_id);
            writer.Write(access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            channel_id = reader.ReadInt32();
            access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(inputPeerChannel channel_id:{0} access_hash:{1})", channel_id, access_hash);
        }
    }

    public class InputUserEmptyConstructor : InputUser
    {
        public InputUserEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputUserEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb98886cf);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputUserEmpty)");
        }
    }

    public class InputUserSelfConstructor : InputUser
    {
        public InputUserSelfConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputUserSelf; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf7c1b13f);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputUserSelf)");
        }
    }

    public class InputUserConstructor : InputUser
    {
        public int user_id;
        public long access_hash;

        public InputUserConstructor() { }

        public InputUserConstructor(int user_id, long access_hash)
        {
            this.user_id = user_id;
            this.access_hash = access_hash;
        }

        public override Constructor Constructor
        { get { return Constructor.inputUser; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd8292816);
            writer.Write(user_id);
            writer.Write(access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(inputUser user_id:{0} access_hash:{1})", user_id, access_hash);
        }
    }

    public class InputPhoneContactConstructor : InputContact
    {
        public long client_id;
        public string phone;
        public string first_name;
        public string last_name;

        public InputPhoneContactConstructor() { }

        public InputPhoneContactConstructor(long client_id, string phone, string first_name, string last_name)
        {
            this.client_id = client_id;
            this.phone = phone;
            this.first_name = first_name;
            this.last_name = last_name;
        }

        public override Constructor Constructor
        { get { return Constructor.inputPhoneContact; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf392b7f4);
            writer.Write(client_id);
            Serializers.String.Write(writer, phone);
            Serializers.String.Write(writer, first_name);
            Serializers.String.Write(writer, last_name);
        }

        public override void Read(BinaryReader reader)
        {
            client_id = reader.ReadInt64();
            phone = Serializers.String.Read(reader);
            first_name = Serializers.String.Read(reader);
            last_name = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputPhoneContact client_id:{0} phone:{1} first_name:{2} last_name:{3})", client_id, phone, first_name, last_name);
        }
    }

    public class InputFileConstructor : InputFile
    {
        public long id;
        public int parts;
        public string name;
        public string md5_checksum;

        public InputFileConstructor() { }

        public InputFileConstructor(long id, int parts, string name, string md5_checksum)
        {
            this.id = id;
            this.parts = parts;
            this.name = name;
            this.md5_checksum = md5_checksum;
        }

        public override Constructor Constructor
        { get { return Constructor.inputFile; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf52ff27f);
            writer.Write(id);
            writer.Write(parts);
            Serializers.String.Write(writer, name);
            Serializers.String.Write(writer, md5_checksum);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            parts = reader.ReadInt32();
            name = Serializers.String.Read(reader);
            md5_checksum = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputFile id:{0} parts:{1} name:{2} md5_checksum:{3})", id, parts, name, md5_checksum);
        }
    }

    public class InputFileBigConstructor : InputFile
    {
        public long id;
        public int parts;
        public string name;

        public InputFileBigConstructor() { }

        public InputFileBigConstructor(long id, int parts, string name)
        {
            this.id = id;
            this.parts = parts;
            this.name = name;
        }

        public override Constructor Constructor
        { get { return Constructor.inputFileBig; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xfa4f0bb5);
            writer.Write(id);
            writer.Write(parts);
            Serializers.String.Write(writer, name);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            parts = reader.ReadInt32();
            name = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputFileBig id:{0} parts:{1} name:{2})", id, parts, name);
        }
    }

    public class InputMediaEmptyConstructor : InputMedia
    {
        public InputMediaEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputMediaEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9664f57f);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputMediaEmpty)");
        }
    }

    public class InputMediaUploadedPhotoConstructor : InputMedia
    {
        public InputFile file;
        public string caption;

        public InputMediaUploadedPhotoConstructor() { }

        public InputMediaUploadedPhotoConstructor(InputFile file, string caption)
        {
            this.file = file;
            this.caption = caption;
        }

        public override Constructor Constructor
        { get { return Constructor.inputMediaUploadedPhoto; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf7aff1c0);
            file.Write(writer);
            Serializers.String.Write(writer, caption);
        }

        public override void Read(BinaryReader reader)
        {
            file = TL.Parse<InputFile>(reader);
            caption = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputMediaUploadedPhoto file:{0} caption:{1})", file, caption);
        }
    }

    public class InputMediaPhotoConstructor : InputMedia
    {
        public InputPhoto id;
        public string caption;

        public InputMediaPhotoConstructor() { }

        public InputMediaPhotoConstructor(InputPhoto id, string caption)
        {
            this.id = id;
            this.caption = caption;
        }

        public override Constructor Constructor
        { get { return Constructor.inputMediaPhoto; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe9bfb4f3);
            id.Write(writer);
            Serializers.String.Write(writer, caption);
        }

        public override void Read(BinaryReader reader)
        {
            id = TL.Parse<InputPhoto>(reader);
            caption = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputMediaPhoto id:{0} caption:{1})", id, caption);
        }
    }

    public class InputMediaGeoPointConstructor : InputMedia
    {
        public InputGeoPoint geo_point;

        public InputMediaGeoPointConstructor() { }

        public InputMediaGeoPointConstructor(InputGeoPoint geo_point)
        {
            this.geo_point = geo_point;
        }

        public override Constructor Constructor
        { get { return Constructor.inputMediaGeoPoint; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf9c44144);
            geo_point.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            geo_point = TL.Parse<InputGeoPoint>(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputMediaGeoPoint geo_point:{0})", geo_point);
        }
    }

    public class InputMediaContactConstructor : InputMedia
    {
        public string phone_number;
        public string first_name;
        public string last_name;

        public InputMediaContactConstructor() { }

        public InputMediaContactConstructor(string phone_number, string first_name, string last_name)
        {
            this.phone_number = phone_number;
            this.first_name = first_name;
            this.last_name = last_name;
        }

        public override Constructor Constructor
        { get { return Constructor.inputMediaContact; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa6e45987);
            Serializers.String.Write(writer, phone_number);
            Serializers.String.Write(writer, first_name);
            Serializers.String.Write(writer, last_name);
        }

        public override void Read(BinaryReader reader)
        {
            phone_number = Serializers.String.Read(reader);
            first_name = Serializers.String.Read(reader);
            last_name = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputMediaContact phone_number:{0} first_name:{1} last_name:{2})", phone_number, first_name, last_name);
        }
    }

    public class InputMediaUploadedVideoConstructor : InputMedia
    {
        public InputFile file;
        public int duration;
        public int w;
        public int h;
        public string mime_type;
        public string caption;

        public InputMediaUploadedVideoConstructor() { }

        public InputMediaUploadedVideoConstructor(InputFile file, int duration, int w, int h, string mime_type, string caption)
        {
            this.file = file;
            this.duration = duration;
            this.w = w;
            this.h = h;
            this.mime_type = mime_type;
            this.caption = caption;
        }

        public override Constructor Constructor
        { get { return Constructor.inputMediaUploadedVideo; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x82713fdf);
            file.Write(writer);
            writer.Write(duration);
            writer.Write(w);
            writer.Write(h);
            Serializers.String.Write(writer, mime_type);
            Serializers.String.Write(writer, caption);
        }

        public override void Read(BinaryReader reader)
        {
            file = TL.Parse<InputFile>(reader);
            duration = reader.ReadInt32();
            w = reader.ReadInt32();
            h = reader.ReadInt32();
            mime_type = Serializers.String.Read(reader);
            caption = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputMediaUploadedVideo file:{0} duration:{1} w:{2} h:{3} mime_type:{4} caption:{5})", file, duration, w, h, mime_type, caption);
        }
    }

    public class InputMediaUploadedThumbVideoConstructor : InputMedia
    {
        public InputFile file;
        public InputFile thumb;
        public int duration;
        public int w;
        public int h;
        public string mime_type;
        public string caption;

        public InputMediaUploadedThumbVideoConstructor() { }

        public InputMediaUploadedThumbVideoConstructor(InputFile file, InputFile thumb, int duration, int w, int h, string mime_type, string caption)
        {
            this.file = file;
            this.thumb = thumb;
            this.duration = duration;
            this.w = w;
            this.h = h;
            this.mime_type = mime_type;
            this.caption = caption;
        }

        public override Constructor Constructor
        { get { return Constructor.inputMediaUploadedThumbVideo; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7780ddf9);
            file.Write(writer);
            thumb.Write(writer);
            writer.Write(duration);
            writer.Write(w);
            writer.Write(h);
            Serializers.String.Write(writer, mime_type);
            Serializers.String.Write(writer, caption);
        }

        public override void Read(BinaryReader reader)
        {
            file = TL.Parse<InputFile>(reader);
            thumb = TL.Parse<InputFile>(reader);
            duration = reader.ReadInt32();
            w = reader.ReadInt32();
            h = reader.ReadInt32();
            mime_type = Serializers.String.Read(reader);
            caption = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputMediaUploadedThumbVideo file:{0} thumb:{1} duration:{2} w:{3} h:{4} mime_type:{5} caption:{6})", file, thumb, duration, w, h, mime_type, caption);
        }
    }

    public class InputMediaVideoConstructor : InputMedia
    {
        public InputVideo id;
        public string caption;

        public InputMediaVideoConstructor() { }

        public InputMediaVideoConstructor(InputVideo id, string caption)
        {
            this.id = id;
            this.caption = caption;
        }

        public override Constructor Constructor
        { get { return Constructor.inputMediaVideo; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x936a4ebd);
            id.Write(writer);
            Serializers.String.Write(writer, caption);
        }

        public override void Read(BinaryReader reader)
        {
            id = TL.Parse<InputVideo>(reader);
            caption = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputMediaVideo id:{0} caption:{1})", id, caption);
        }
    }

    public class InputMediaUploadedAudioConstructor : InputMedia
    {
        public InputFile file;
        public int duration;
        public string mime_type;

        public InputMediaUploadedAudioConstructor() { }

        public InputMediaUploadedAudioConstructor(InputFile file, int duration, string mime_type)
        {
            this.file = file;
            this.duration = duration;
            this.mime_type = mime_type;
        }

        public override Constructor Constructor
        { get { return Constructor.inputMediaUploadedAudio; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4e498cab);
            file.Write(writer);
            writer.Write(duration);
            Serializers.String.Write(writer, mime_type);
        }

        public override void Read(BinaryReader reader)
        {
            file = TL.Parse<InputFile>(reader);
            duration = reader.ReadInt32();
            mime_type = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputMediaUploadedAudio file:{0} duration:{1} mime_type:{2})", file, duration, mime_type);
        }
    }

    public class InputMediaAudioConstructor : InputMedia
    {
        public InputAudio id;

        public InputMediaAudioConstructor() { }

        public InputMediaAudioConstructor(InputAudio id)
        {
            this.id = id;
        }

        public override Constructor Constructor
        { get { return Constructor.inputMediaAudio; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x89938781);
            id.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            id = TL.Parse<InputAudio>(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputMediaAudio id:{0})", id);
        }
    }

    public class InputMediaUploadedDocumentConstructor : InputMedia
    {
        public InputFile file;
        public string mime_type;
        public List<DocumentAttribute> attributes;

        public InputMediaUploadedDocumentConstructor() { }

        public InputMediaUploadedDocumentConstructor(InputFile file, string mime_type, List<DocumentAttribute> attributes)
        {
            this.file = file;
            this.mime_type = mime_type;
            this.attributes = attributes;
        }

        public override Constructor Constructor
        { get { return Constructor.inputMediaUploadedDocument; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xffe76b78);
            file.Write(writer);
            Serializers.String.Write(writer, mime_type);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(attributes.Count);
            foreach (DocumentAttribute attributes_element in attributes)
                attributes_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            file = TL.Parse<InputFile>(reader);
            mime_type = Serializers.String.Read(reader);
            reader.ReadUInt32(); // vector code
            int attributes_count = reader.ReadInt32();
            attributes = new List<DocumentAttribute>(attributes_count);
            for (int attributes_index = 0; attributes_index < attributes_count; attributes_index++)
                attributes.Add(TL.Parse<DocumentAttribute>(reader));
        }

        public override string ToString()
        {
            return string.Format("(inputMediaUploadedDocument file:{0} mime_type:{1} attributes:{2})", file, mime_type, attributes);
        }
    }

    public class InputMediaUploadedThumbDocumentConstructor : InputMedia
    {
        public InputFile file;
        public InputFile thumb;
        public string mime_type;
        public List<DocumentAttribute> attributes;

        public InputMediaUploadedThumbDocumentConstructor() { }

        public InputMediaUploadedThumbDocumentConstructor(InputFile file, InputFile thumb, string mime_type, List<DocumentAttribute> attributes)
        {
            this.file = file;
            this.thumb = thumb;
            this.mime_type = mime_type;
            this.attributes = attributes;
        }

        public override Constructor Constructor
        { get { return Constructor.inputMediaUploadedThumbDocument; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x41481486);
            file.Write(writer);
            thumb.Write(writer);
            Serializers.String.Write(writer, mime_type);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(attributes.Count);
            foreach (DocumentAttribute attributes_element in attributes)
                attributes_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            file = TL.Parse<InputFile>(reader);
            thumb = TL.Parse<InputFile>(reader);
            mime_type = Serializers.String.Read(reader);
            reader.ReadUInt32(); // vector code
            int attributes_count = reader.ReadInt32();
            attributes = new List<DocumentAttribute>(attributes_count);
            for (int attributes_index = 0; attributes_index < attributes_count; attributes_index++)
                attributes.Add(TL.Parse<DocumentAttribute>(reader));
        }

        public override string ToString()
        {
            return string.Format("(inputMediaUploadedThumbDocument file:{0} thumb:{1} mime_type:{2} attributes:{3})", file, thumb, mime_type, attributes);
        }
    }

    public class InputMediaDocumentConstructor : InputMedia
    {
        public InputDocument id;

        public InputMediaDocumentConstructor() { }

        public InputMediaDocumentConstructor(InputDocument id)
        {
            this.id = id;
        }

        public override Constructor Constructor
        { get { return Constructor.inputMediaDocument; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd184e841);
            id.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            id = TL.Parse<InputDocument>(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputMediaDocument id:{0})", id);
        }
    }

    public class InputMediaVenueConstructor : InputMedia
    {
        public InputGeoPoint geo_point;
        public string title;
        public string address;
        public string provider;
        public string venue_id;

        public InputMediaVenueConstructor() { }

        public InputMediaVenueConstructor(InputGeoPoint geo_point, string title, string address, string provider, string venue_id)
        {
            this.geo_point = geo_point;
            this.title = title;
            this.address = address;
            this.provider = provider;
            this.venue_id = venue_id;
        }

        public override Constructor Constructor
        { get { return Constructor.inputMediaVenue; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2827a81a);
            geo_point.Write(writer);
            Serializers.String.Write(writer, title);
            Serializers.String.Write(writer, address);
            Serializers.String.Write(writer, provider);
            Serializers.String.Write(writer, venue_id);
        }

        public override void Read(BinaryReader reader)
        {
            geo_point = TL.Parse<InputGeoPoint>(reader);
            title = Serializers.String.Read(reader);
            address = Serializers.String.Read(reader);
            provider = Serializers.String.Read(reader);
            venue_id = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputMediaVenue geo_point:{0} title:{1} address:{2} provider:{3} venue_id:{4})", geo_point, title, address, provider, venue_id);
        }
    }

    public class InputChatPhotoEmptyConstructor : InputChatPhoto
    {
        public InputChatPhotoEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputChatPhotoEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1ca48f57);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputChatPhotoEmpty)");
        }
    }

    public class InputChatUploadedPhotoConstructor : InputChatPhoto
    {
        public InputFile file;
        public InputPhotoCrop crop;

        public InputChatUploadedPhotoConstructor() { }

        public InputChatUploadedPhotoConstructor(InputFile file, InputPhotoCrop crop)
        {
            this.file = file;
            this.crop = crop;
        }

        public override Constructor Constructor
        { get { return Constructor.inputChatUploadedPhoto; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x94254732);
            file.Write(writer);
            crop.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            file = TL.Parse<InputFile>(reader);
            crop = TL.Parse<InputPhotoCrop>(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputChatUploadedPhoto file:{0} crop:{1})", file, crop);
        }
    }

    public class InputChatPhotoConstructor : InputChatPhoto
    {
        public InputPhoto id;
        public InputPhotoCrop crop;

        public InputChatPhotoConstructor() { }

        public InputChatPhotoConstructor(InputPhoto id, InputPhotoCrop crop)
        {
            this.id = id;
            this.crop = crop;
        }

        public override Constructor Constructor
        { get { return Constructor.inputChatPhoto; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb2e1bf08);
            id.Write(writer);
            crop.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            id = TL.Parse<InputPhoto>(reader);
            crop = TL.Parse<InputPhotoCrop>(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputChatPhoto id:{0} crop:{1})", id, crop);
        }
    }

    public class InputGeoPointEmptyConstructor : InputGeoPoint
    {
        public InputGeoPointEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputGeoPointEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe4c123d6);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputGeoPointEmpty)");
        }
    }

    public class InputGeoPointConstructor : InputGeoPoint
    {
        public double lat;
        public double @long;

        public InputGeoPointConstructor() { }

        public InputGeoPointConstructor(double lat, double @long)
        {
            this.lat = lat;
            this.@long = @long;
        }

        public override Constructor Constructor
        { get { return Constructor.inputGeoPoint; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf3b7acc9);
            writer.Write(lat);
            writer.Write(@long);
        }

        public override void Read(BinaryReader reader)
        {
            lat = reader.ReadDouble();
            @long = reader.ReadDouble();
        }

        public override string ToString()
        {
            return string.Format("(inputGeoPoint lat:{0} @long:{1})", lat, @long);
        }
    }

    public class InputPhotoEmptyConstructor : InputPhoto
    {
        public InputPhotoEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputPhotoEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1cd7bf0d);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputPhotoEmpty)");
        }
    }

    public class InputPhotoConstructor : InputPhoto
    {
        public long id;
        public long access_hash;

        public InputPhotoConstructor() { }

        public InputPhotoConstructor(long id, long access_hash)
        {
            this.id = id;
            this.access_hash = access_hash;
        }

        public override Constructor Constructor
        { get { return Constructor.inputPhoto; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xfb95c6c4);
            writer.Write(id);
            writer.Write(access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(inputPhoto id:{0} access_hash:{1})", id, access_hash);
        }
    }

    public class InputVideoEmptyConstructor : InputVideo
    {
        public InputVideoEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputVideoEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5508ec75);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputVideoEmpty)");
        }
    }

    public class InputVideoConstructor : InputVideo
    {
        public long id;
        public long access_hash;

        public InputVideoConstructor() { }

        public InputVideoConstructor(long id, long access_hash)
        {
            this.id = id;
            this.access_hash = access_hash;
        }

        public override Constructor Constructor
        { get { return Constructor.inputVideo; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xee579652);
            writer.Write(id);
            writer.Write(access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(inputVideo id:{0} access_hash:{1})", id, access_hash);
        }
    }

    public class InputFileLocationConstructor : InputFileLocation
    {
        public long volume_id;
        public int local_id;
        public long secret;

        public InputFileLocationConstructor() { }

        public InputFileLocationConstructor(long volume_id, int local_id, long secret)
        {
            this.volume_id = volume_id;
            this.local_id = local_id;
            this.secret = secret;
        }

        public override Constructor Constructor
        { get { return Constructor.inputFileLocation; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x14637196);
            writer.Write(volume_id);
            writer.Write(local_id);
            writer.Write(secret);
        }

        public override void Read(BinaryReader reader)
        {
            volume_id = reader.ReadInt64();
            local_id = reader.ReadInt32();
            secret = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(inputFileLocation volume_id:{0} local_id:{1} secret:{2})", volume_id, local_id, secret);
        }
    }

    public class InputVideoFileLocationConstructor : InputFileLocation
    {
        public long id;
        public long access_hash;

        public InputVideoFileLocationConstructor() { }

        public InputVideoFileLocationConstructor(long id, long access_hash)
        {
            this.id = id;
            this.access_hash = access_hash;
        }

        public override Constructor Constructor
        { get { return Constructor.inputVideoFileLocation; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x3d0364ec);
            writer.Write(id);
            writer.Write(access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(inputVideoFileLocation id:{0} access_hash:{1})", id, access_hash);
        }
    }

    public class InputEncryptedFileLocationConstructor : InputFileLocation
    {
        public long id;
        public long access_hash;

        public InputEncryptedFileLocationConstructor() { }

        public InputEncryptedFileLocationConstructor(long id, long access_hash)
        {
            this.id = id;
            this.access_hash = access_hash;
        }

        public override Constructor Constructor
        { get { return Constructor.inputEncryptedFileLocation; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf5235d55);
            writer.Write(id);
            writer.Write(access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(inputEncryptedFileLocation id:{0} access_hash:{1})", id, access_hash);
        }
    }

    public class InputAudioFileLocationConstructor : InputFileLocation
    {
        public long id;
        public long access_hash;

        public InputAudioFileLocationConstructor() { }

        public InputAudioFileLocationConstructor(long id, long access_hash)
        {
            this.id = id;
            this.access_hash = access_hash;
        }

        public override Constructor Constructor
        { get { return Constructor.inputAudioFileLocation; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x74dc404d);
            writer.Write(id);
            writer.Write(access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(inputAudioFileLocation id:{0} access_hash:{1})", id, access_hash);
        }
    }

    public class InputDocumentFileLocationConstructor : InputFileLocation
    {
        public long id;
        public long access_hash;

        public InputDocumentFileLocationConstructor() { }

        public InputDocumentFileLocationConstructor(long id, long access_hash)
        {
            this.id = id;
            this.access_hash = access_hash;
        }

        public override Constructor Constructor
        { get { return Constructor.inputDocumentFileLocation; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4e45abe9);
            writer.Write(id);
            writer.Write(access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(inputDocumentFileLocation id:{0} access_hash:{1})", id, access_hash);
        }
    }

    public class InputPhotoCropAutoConstructor : InputPhotoCrop
    {
        public InputPhotoCropAutoConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputPhotoCropAuto; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xade6b004);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputPhotoCropAuto)");
        }
    }

    public class InputPhotoCropConstructor : InputPhotoCrop
    {
        public double crop_left;
        public double crop_top;
        public double crop_width;

        public InputPhotoCropConstructor() { }

        public InputPhotoCropConstructor(double crop_left, double crop_top, double crop_width)
        {
            this.crop_left = crop_left;
            this.crop_top = crop_top;
            this.crop_width = crop_width;
        }

        public override Constructor Constructor
        { get { return Constructor.inputPhotoCrop; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd9915325);
            writer.Write(crop_left);
            writer.Write(crop_top);
            writer.Write(crop_width);
        }

        public override void Read(BinaryReader reader)
        {
            crop_left = reader.ReadDouble();
            crop_top = reader.ReadDouble();
            crop_width = reader.ReadDouble();
        }

        public override string ToString()
        {
            return string.Format("(inputPhotoCrop crop_left:{0} crop_top:{1} crop_width:{2})", crop_left, crop_top, crop_width);
        }
    }

    public class InputAppEventConstructor : InputAppEvent
    {
        public double time;
        public string type;
        public long peer;
        public string data;

        public InputAppEventConstructor() { }

        public InputAppEventConstructor(double time, string type, long peer, string data)
        {
            this.time = time;
            this.type = type;
            this.peer = peer;
            this.data = data;
        }

        public override Constructor Constructor
        { get { return Constructor.inputAppEvent; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x770656a8);
            writer.Write(time);
            Serializers.String.Write(writer, type);
            writer.Write(peer);
            Serializers.String.Write(writer, data);
        }

        public override void Read(BinaryReader reader)
        {
            time = reader.ReadDouble();
            type = Serializers.String.Read(reader);
            peer = reader.ReadInt64();
            data = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputAppEvent time:{0} type:{1} peer:{2} data:{3})", time, type, peer, data);
        }
    }

    public class PeerUserConstructor : Peer
    {
        public int user_id;

        public PeerUserConstructor() { }

        public PeerUserConstructor(int user_id)
        {
            this.user_id = user_id;
        }

        public override Constructor Constructor
        { get { return Constructor.peerUser; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9db1bc6d);
            writer.Write(user_id);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(peerUser user_id:{0})", user_id);
        }
    }

    public class PeerChatConstructor : Peer
    {
        public int chat_id;

        public PeerChatConstructor() { }

        public PeerChatConstructor(int chat_id)
        {
            this.chat_id = chat_id;
        }

        public override Constructor Constructor
        { get { return Constructor.peerChat; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xbad0e5bb);
            writer.Write(chat_id);
        }

        public override void Read(BinaryReader reader)
        {
            chat_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(peerChat chat_id:{0})", chat_id);
        }
    }

    public class PeerChannelConstructor : Peer
    {
        public int channel_id;

        public PeerChannelConstructor() { }

        public PeerChannelConstructor(int channel_id)
        {
            this.channel_id = channel_id;
        }

        public override Constructor Constructor
        { get { return Constructor.peerChannel; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xbddde532);
            writer.Write(channel_id);
        }

        public override void Read(BinaryReader reader)
        {
            channel_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(peerChannel channel_id:{0})", channel_id);
        }
    }

    public class Storage_fileUnknownConstructor : storage_FileType
    {
        public Storage_fileUnknownConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.storage_fileUnknown; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xaa963b05);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(storage_fileUnknown)");
        }
    }

    public class Storage_fileJpegConstructor : storage_FileType
    {
        public Storage_fileJpegConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.storage_fileJpeg; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7efe0e);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(storage_fileJpeg)");
        }
    }

    public class Storage_fileGifConstructor : storage_FileType
    {
        public Storage_fileGifConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.storage_fileGif; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xcae1aadf);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(storage_fileGif)");
        }
    }

    public class Storage_filePngConstructor : storage_FileType
    {
        public Storage_filePngConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.storage_filePng; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa4f63c0);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(storage_filePng)");
        }
    }

    public class Storage_filePdfConstructor : storage_FileType
    {
        public Storage_filePdfConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.storage_filePdf; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xae1e508d);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(storage_filePdf)");
        }
    }

    public class Storage_fileMp3Constructor : storage_FileType
    {
        public Storage_fileMp3Constructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.storage_fileMp3; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x528a0677);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(storage_fileMp3)");
        }
    }

    public class Storage_fileMovConstructor : storage_FileType
    {
        public Storage_fileMovConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.storage_fileMov; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4b09ebbc);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(storage_fileMov)");
        }
    }

    public class Storage_filePartialConstructor : storage_FileType
    {
        public Storage_filePartialConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.storage_filePartial; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x40bc6f52);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(storage_filePartial)");
        }
    }

    public class Storage_fileMp4Constructor : storage_FileType
    {
        public Storage_fileMp4Constructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.storage_fileMp4; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb3cea0e4);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(storage_fileMp4)");
        }
    }

    public class Storage_fileWebpConstructor : storage_FileType
    {
        public Storage_fileWebpConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.storage_fileWebp; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1081464c);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(storage_fileWebp)");
        }
    }

    public class FileLocationUnavailableConstructor : FileLocation
    {
        public long volume_id;
        public int local_id;
        public long secret;

        public FileLocationUnavailableConstructor() { }

        public FileLocationUnavailableConstructor(long volume_id, int local_id, long secret)
        {
            this.volume_id = volume_id;
            this.local_id = local_id;
            this.secret = secret;
        }

        public override Constructor Constructor
        { get { return Constructor.fileLocationUnavailable; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7c596b46);
            writer.Write(volume_id);
            writer.Write(local_id);
            writer.Write(secret);
        }

        public override void Read(BinaryReader reader)
        {
            volume_id = reader.ReadInt64();
            local_id = reader.ReadInt32();
            secret = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(fileLocationUnavailable volume_id:{0} local_id:{1} secret:{2})", volume_id, local_id, secret);
        }
    }

    public class FileLocationConstructor : FileLocation
    {
        public int dc_id;
        public long volume_id;
        public int local_id;
        public long secret;

        public FileLocationConstructor() { }

        public FileLocationConstructor(int dc_id, long volume_id, int local_id, long secret)
        {
            this.dc_id = dc_id;
            this.volume_id = volume_id;
            this.local_id = local_id;
            this.secret = secret;
        }

        public override Constructor Constructor
        { get { return Constructor.fileLocation; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x53d69076);
            writer.Write(dc_id);
            writer.Write(volume_id);
            writer.Write(local_id);
            writer.Write(secret);
        }

        public override void Read(BinaryReader reader)
        {
            dc_id = reader.ReadInt32();
            volume_id = reader.ReadInt64();
            local_id = reader.ReadInt32();
            secret = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(fileLocation dc_id:{0} volume_id:{1} local_id:{2} secret:{3})", dc_id, volume_id, local_id, secret);
        }
    }

    public class UserEmptyConstructor : User
    {
        public int id;

        public UserEmptyConstructor() { }

        public UserEmptyConstructor(int id)
        {
            this.id = id;
        }

        public override Constructor Constructor
        { get { return Constructor.userEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x200250ba);
            writer.Write(id);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(userEmpty id:{0})", id);
        }
    }

    public class UserConstructor : User
    {
        public int flags;
        public int id;
        public long? access_hash;
        public string first_name;
        public string last_name;
        public string username;
        public string phone;
        public UserProfilePhoto photo;
        public UserStatus status;
        public int? bot_info_version;

        public UserConstructor() { }

        public UserConstructor(int flags, int id, long? access_hash, string first_name, string last_name, string username, string phone, UserProfilePhoto photo, UserStatus status, int? bot_info_version)
        {
            this.flags = flags;
            this.id = id;
            this.access_hash = access_hash;
            this.first_name = first_name;
            this.last_name = last_name;
            this.username = username;
            this.phone = phone;
            this.photo = photo;
            this.status = status;
            this.bot_info_version = bot_info_version;
        }

        public override Constructor Constructor
        { get { return Constructor.user; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x22e49072);
            // Calculate flags value
            flags = 0;
            if (access_hash != null) flags += 1;
            if (first_name != null) flags += 2;
            if (last_name != null) flags += 4;
            if (username != null) flags += 8;
            if (phone != null) flags += 16;
            if (photo != null) flags += 32;
            if (status != null) flags += 64;
            if (bot_info_version != null) flags += 16384;

            writer.Write(flags);
            writer.Write(id);
            if (access_hash != null)
            {
                writer.Write(access_hash.Value);
            }
            if (first_name != null)
            {
                Serializers.String.Write(writer, first_name);
            }
            if (last_name != null)
            {
                Serializers.String.Write(writer, last_name);
            }
            if (username != null)
            {
                Serializers.String.Write(writer, username);
            }
            if (phone != null)
            {
                Serializers.String.Write(writer, phone);
            }
            if (photo != null)
            {
                photo.Write(writer);
            }
            if (status != null)
            {
                status.Write(writer);
            }
            if (bot_info_version != null)
            {
                writer.Write(bot_info_version.Value);
            }
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            id = reader.ReadInt32();
            if ((flags & 1) != 0)
            {
                access_hash = reader.ReadInt64();
            }
            if ((flags & 2) != 0)
            {
                first_name = Serializers.String.Read(reader);
            }
            if ((flags & 4) != 0)
            {
                last_name = Serializers.String.Read(reader);
            }
            if ((flags & 8) != 0)
            {
                username = Serializers.String.Read(reader);
            }
            if ((flags & 16) != 0)
            {
                phone = Serializers.String.Read(reader);
            }
            if ((flags & 32) != 0)
            {
                photo = TL.Parse<UserProfilePhoto>(reader);
            }
            if ((flags & 64) != 0)
            {
                status = TL.Parse<UserStatus>(reader);
            }
            if ((flags & 16384) != 0)
            {
                bot_info_version = reader.ReadInt32();
            }
        }

        public override string ToString()
        {
            return string.Format("(user flags:{0} id:{1} access_hash:{2} first_name:{3} last_name:{4} username:{5} phone:{6} photo:{7} status:{8} bot_info_version:{9})", flags, id, access_hash, first_name, last_name, username, phone, photo, status, bot_info_version);
        }
    }

    public class UserProfilePhotoEmptyConstructor : UserProfilePhoto
    {
        public UserProfilePhotoEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.userProfilePhotoEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4f11bae1);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(userProfilePhotoEmpty)");
        }
    }

    public class UserProfilePhotoConstructor : UserProfilePhoto
    {
        public long photo_id;
        public FileLocation photo_small;
        public FileLocation photo_big;

        public UserProfilePhotoConstructor() { }

        public UserProfilePhotoConstructor(long photo_id, FileLocation photo_small, FileLocation photo_big)
        {
            this.photo_id = photo_id;
            this.photo_small = photo_small;
            this.photo_big = photo_big;
        }

        public override Constructor Constructor
        { get { return Constructor.userProfilePhoto; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd559d8c8);
            writer.Write(photo_id);
            photo_small.Write(writer);
            photo_big.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            photo_id = reader.ReadInt64();
            photo_small = TL.Parse<FileLocation>(reader);
            photo_big = TL.Parse<FileLocation>(reader);
        }

        public override string ToString()
        {
            return string.Format("(userProfilePhoto photo_id:{0} photo_small:{1} photo_big:{2})", photo_id, photo_small, photo_big);
        }
    }

    public class UserStatusEmptyConstructor : UserStatus
    {
        public UserStatusEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.userStatusEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9d05049);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(userStatusEmpty)");
        }
    }

    public class UserStatusOnlineConstructor : UserStatus
    {
        public int expires;

        public UserStatusOnlineConstructor() { }

        public UserStatusOnlineConstructor(int expires)
        {
            this.expires = expires;
        }

        public override Constructor Constructor
        { get { return Constructor.userStatusOnline; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xedb93949);
            writer.Write(expires);
        }

        public override void Read(BinaryReader reader)
        {
            expires = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(userStatusOnline expires:{0})", expires);
        }
    }

    public class UserStatusOfflineConstructor : UserStatus
    {
        public int was_online;

        public UserStatusOfflineConstructor() { }

        public UserStatusOfflineConstructor(int was_online)
        {
            this.was_online = was_online;
        }

        public override Constructor Constructor
        { get { return Constructor.userStatusOffline; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x8c703f);
            writer.Write(was_online);
        }

        public override void Read(BinaryReader reader)
        {
            was_online = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(userStatusOffline was_online:{0})", was_online);
        }
    }

    public class UserStatusRecentlyConstructor : UserStatus
    {
        public UserStatusRecentlyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.userStatusRecently; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe26f42f1);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(userStatusRecently)");
        }
    }

    public class UserStatusLastWeekConstructor : UserStatus
    {
        public UserStatusLastWeekConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.userStatusLastWeek; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7bf09fc);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(userStatusLastWeek)");
        }
    }

    public class UserStatusLastMonthConstructor : UserStatus
    {
        public UserStatusLastMonthConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.userStatusLastMonth; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x77ebc742);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(userStatusLastMonth)");
        }
    }

    public class ChatEmptyConstructor : Chat
    {
        public int id;

        public ChatEmptyConstructor() { }

        public ChatEmptyConstructor(int id)
        {
            this.id = id;
        }

        public override Constructor Constructor
        { get { return Constructor.chatEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9ba2d800);
            writer.Write(id);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(chatEmpty id:{0})", id);
        }
    }

    public class ChatConstructor : Chat
    {
        public int flags;
        public int id;
        public string title;
        public ChatPhoto photo;
        public int participants_count;
        public int date;
        public int version;

        public ChatConstructor() { }

        public ChatConstructor(int flags, int id, string title, ChatPhoto photo, int participants_count, int date, int version)
        {
            this.flags = flags;
            this.id = id;
            this.title = title;
            this.photo = photo;
            this.participants_count = participants_count;
            this.date = date;
            this.version = version;
        }

        public override Constructor Constructor
        { get { return Constructor.chat; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7312bc48);
            // Calculate flags value
            flags = 0;

            writer.Write(flags);
            writer.Write(id);
            Serializers.String.Write(writer, title);
            photo.Write(writer);
            writer.Write(participants_count);
            writer.Write(date);
            writer.Write(version);
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            id = reader.ReadInt32();
            title = Serializers.String.Read(reader);
            photo = TL.Parse<ChatPhoto>(reader);
            participants_count = reader.ReadInt32();
            date = reader.ReadInt32();
            version = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(chat flags:{0} id:{1} title:{2} photo:{3} participants_count:{4} date:{5} version:{6})", flags, id, title, photo, participants_count, date, version);
        }
    }

    public class ChatForbiddenConstructor : Chat
    {
        public int id;
        public string title;

        public ChatForbiddenConstructor() { }

        public ChatForbiddenConstructor(int id, string title)
        {
            this.id = id;
            this.title = title;
        }

        public override Constructor Constructor
        { get { return Constructor.chatForbidden; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7328bdb);
            writer.Write(id);
            Serializers.String.Write(writer, title);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt32();
            title = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(chatForbidden id:{0} title:{1})", id, title);
        }
    }

    public class ChannelConstructor : Chat
    {
        public int flags;
        public int id;
        public long access_hash;
        public string title;
        public string username;
        public ChatPhoto photo;
        public int date;
        public int version;

        public ChannelConstructor() { }

        public ChannelConstructor(int flags, int id, long access_hash, string title, string username, ChatPhoto photo, int date, int version)
        {
            this.flags = flags;
            this.id = id;
            this.access_hash = access_hash;
            this.title = title;
            this.username = username;
            this.photo = photo;
            this.date = date;
            this.version = version;
        }

        public override Constructor Constructor
        { get { return Constructor.channel; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x678e9587);
            // Calculate flags value
            flags = 0;
            if (username != null) flags += 64;

            writer.Write(flags);
            writer.Write(id);
            writer.Write(access_hash);
            Serializers.String.Write(writer, title);
            if (username != null)
            {
                Serializers.String.Write(writer, username);
            }
            photo.Write(writer);
            writer.Write(date);
            writer.Write(version);
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            id = reader.ReadInt32();
            access_hash = reader.ReadInt64();
            title = Serializers.String.Read(reader);
            if ((flags & 64) != 0)
            {
                username = Serializers.String.Read(reader);
            }
            photo = TL.Parse<ChatPhoto>(reader);
            date = reader.ReadInt32();
            version = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(channel flags:{0} id:{1} access_hash:{2} title:{3} username:{4} photo:{5} date:{6} version:{7})", flags, id, access_hash, title, username, photo, date, version);
        }
    }

    public class ChannelForbiddenConstructor : Chat
    {
        public int id;
        public long access_hash;
        public string title;

        public ChannelForbiddenConstructor() { }

        public ChannelForbiddenConstructor(int id, long access_hash, string title)
        {
            this.id = id;
            this.access_hash = access_hash;
            this.title = title;
        }

        public override Constructor Constructor
        { get { return Constructor.channelForbidden; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2d85832c);
            writer.Write(id);
            writer.Write(access_hash);
            Serializers.String.Write(writer, title);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt32();
            access_hash = reader.ReadInt64();
            title = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(channelForbidden id:{0} access_hash:{1} title:{2})", id, access_hash, title);
        }
    }

    public class ChatFullConstructor : ChatFull
    {
        public int id;
        public ChatParticipants participants;
        public Photo chat_photo;
        public PeerNotifySettings notify_settings;
        public ExportedChatInvite exported_invite;
        public List<BotInfo> bot_info;

        public ChatFullConstructor() { }

        public ChatFullConstructor(int id, ChatParticipants participants, Photo chat_photo, PeerNotifySettings notify_settings, ExportedChatInvite exported_invite, List<BotInfo> bot_info)
        {
            this.id = id;
            this.participants = participants;
            this.chat_photo = chat_photo;
            this.notify_settings = notify_settings;
            this.exported_invite = exported_invite;
            this.bot_info = bot_info;
        }

        public override Constructor Constructor
        { get { return Constructor.chatFull; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2e02a614);
            writer.Write(id);
            participants.Write(writer);
            chat_photo.Write(writer);
            notify_settings.Write(writer);
            exported_invite.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(bot_info.Count);
            foreach (BotInfo bot_info_element in bot_info)
                bot_info_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt32();
            participants = TL.Parse<ChatParticipants>(reader);
            chat_photo = TL.Parse<Photo>(reader);
            notify_settings = TL.Parse<PeerNotifySettings>(reader);
            exported_invite = TL.Parse<ExportedChatInvite>(reader);
            reader.ReadUInt32(); // vector code
            int bot_info_count = reader.ReadInt32();
            bot_info = new List<BotInfo>(bot_info_count);
            for (int bot_info_index = 0; bot_info_index < bot_info_count; bot_info_index++)
                bot_info.Add(TL.Parse<BotInfo>(reader));
        }

        public override string ToString()
        {
            return string.Format("(chatFull id:{0} participants:{1} chat_photo:{2} notify_settings:{3} exported_invite:{4} bot_info:{5})", id, participants, chat_photo, notify_settings, exported_invite, bot_info);
        }
    }

    public class ChannelFullConstructor : ChatFull
    {
        public int flags;
        public int id;
        public string about;
        public int? participants_count;
        public int? admins_count;
        public int? kicked_count;
        public int read_inbox_max_id;
        public int unread_count;
        public int unread_important_count;
        public Photo chat_photo;
        public PeerNotifySettings notify_settings;
        public ExportedChatInvite exported_invite;

        public ChannelFullConstructor() { }

        public ChannelFullConstructor(int flags, int id, string about, int? participants_count, int? admins_count, int? kicked_count, int read_inbox_max_id, int unread_count, int unread_important_count, Photo chat_photo, PeerNotifySettings notify_settings, ExportedChatInvite exported_invite)
        {
            this.flags = flags;
            this.id = id;
            this.about = about;
            this.participants_count = participants_count;
            this.admins_count = admins_count;
            this.kicked_count = kicked_count;
            this.read_inbox_max_id = read_inbox_max_id;
            this.unread_count = unread_count;
            this.unread_important_count = unread_important_count;
            this.chat_photo = chat_photo;
            this.notify_settings = notify_settings;
            this.exported_invite = exported_invite;
        }

        public override Constructor Constructor
        { get { return Constructor.channelFull; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xfab31aa3);
            // Calculate flags value
            flags = 0;
            if (participants_count != null) flags += 1;
            if (admins_count != null) flags += 2;
            if (kicked_count != null) flags += 4;

            writer.Write(flags);
            writer.Write(id);
            Serializers.String.Write(writer, about);
            if (participants_count != null)
            {
                writer.Write(participants_count.Value);
            }
            if (admins_count != null)
            {
                writer.Write(admins_count.Value);
            }
            if (kicked_count != null)
            {
                writer.Write(kicked_count.Value);
            }
            writer.Write(read_inbox_max_id);
            writer.Write(unread_count);
            writer.Write(unread_important_count);
            chat_photo.Write(writer);
            notify_settings.Write(writer);
            exported_invite.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            id = reader.ReadInt32();
            about = Serializers.String.Read(reader);
            if ((flags & 1) != 0)
            {
                participants_count = reader.ReadInt32();
            }
            if ((flags & 2) != 0)
            {
                admins_count = reader.ReadInt32();
            }
            if ((flags & 4) != 0)
            {
                kicked_count = reader.ReadInt32();
            }
            read_inbox_max_id = reader.ReadInt32();
            unread_count = reader.ReadInt32();
            unread_important_count = reader.ReadInt32();
            chat_photo = TL.Parse<Photo>(reader);
            notify_settings = TL.Parse<PeerNotifySettings>(reader);
            exported_invite = TL.Parse<ExportedChatInvite>(reader);
        }

        public override string ToString()
        {
            return string.Format("(channelFull flags:{0} id:{1} about:{2} participants_count:{3} admins_count:{4} kicked_count:{5} read_inbox_max_id:{6} unread_count:{7} unread_important_count:{8} chat_photo:{9} notify_settings:{10} exported_invite:{11})", flags, id, about, participants_count, admins_count, kicked_count, read_inbox_max_id, unread_count, unread_important_count, chat_photo, notify_settings, exported_invite);
        }
    }

    public class ChatParticipantConstructor : ChatParticipant
    {
        public int user_id;
        public int inviter_id;
        public int date;

        public ChatParticipantConstructor() { }

        public ChatParticipantConstructor(int user_id, int inviter_id, int date)
        {
            this.user_id = user_id;
            this.inviter_id = inviter_id;
            this.date = date;
        }

        public override Constructor Constructor
        { get { return Constructor.chatParticipant; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc8d7493e);
            writer.Write(user_id);
            writer.Write(inviter_id);
            writer.Write(date);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            inviter_id = reader.ReadInt32();
            date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(chatParticipant user_id:{0} inviter_id:{1} date:{2})", user_id, inviter_id, date);
        }
    }

    public class ChatParticipantsForbiddenConstructor : ChatParticipants
    {
        public int flags;
        public int chat_id;
        public ChatParticipant self_participant;

        public ChatParticipantsForbiddenConstructor() { }

        public ChatParticipantsForbiddenConstructor(int flags, int chat_id, ChatParticipant self_participant)
        {
            this.flags = flags;
            this.chat_id = chat_id;
            this.self_participant = self_participant;
        }

        public override Constructor Constructor
        { get { return Constructor.chatParticipantsForbidden; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xfc900c2b);
            // Calculate flags value
            flags = 0;
            if (self_participant != null) flags += 1;

            writer.Write(flags);
            writer.Write(chat_id);
            if (self_participant != null)
            {
                self_participant.Write(writer);
            }
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            chat_id = reader.ReadInt32();
            if ((flags & 1) != 0)
            {
                self_participant = TL.Parse<ChatParticipant>(reader);
            }
        }

        public override string ToString()
        {
            return string.Format("(chatParticipantsForbidden flags:{0} chat_id:{1} self_participant:{2})", flags, chat_id, self_participant);
        }
    }

    public class ChatParticipantsConstructor : ChatParticipants
    {
        public int chat_id;
        public int admin_id;
        public List<ChatParticipant> participants;
        public int version;

        public ChatParticipantsConstructor() { }

        public ChatParticipantsConstructor(int chat_id, int admin_id, List<ChatParticipant> participants, int version)
        {
            this.chat_id = chat_id;
            this.admin_id = admin_id;
            this.participants = participants;
            this.version = version;
        }

        public override Constructor Constructor
        { get { return Constructor.chatParticipants; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7841b415);
            writer.Write(chat_id);
            writer.Write(admin_id);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(participants.Count);
            foreach (ChatParticipant participants_element in participants)
                participants_element.Write(writer);
            writer.Write(version);
        }

        public override void Read(BinaryReader reader)
        {
            chat_id = reader.ReadInt32();
            admin_id = reader.ReadInt32();
            reader.ReadUInt32(); // vector code
            int participants_count = reader.ReadInt32();
            participants = new List<ChatParticipant>(participants_count);
            for (int participants_index = 0; participants_index < participants_count; participants_index++)
                participants.Add(TL.Parse<ChatParticipant>(reader));
            version = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(chatParticipants chat_id:{0} admin_id:{1} participants:{2} version:{3})", chat_id, admin_id, participants, version);
        }
    }

    public class ChatPhotoEmptyConstructor : ChatPhoto
    {
        public ChatPhotoEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.chatPhotoEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x37c1011c);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(chatPhotoEmpty)");
        }
    }

    public class ChatPhotoConstructor : ChatPhoto
    {
        public FileLocation photo_small;
        public FileLocation photo_big;

        public ChatPhotoConstructor() { }

        public ChatPhotoConstructor(FileLocation photo_small, FileLocation photo_big)
        {
            this.photo_small = photo_small;
            this.photo_big = photo_big;
        }

        public override Constructor Constructor
        { get { return Constructor.chatPhoto; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6153276a);
            photo_small.Write(writer);
            photo_big.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            photo_small = TL.Parse<FileLocation>(reader);
            photo_big = TL.Parse<FileLocation>(reader);
        }

        public override string ToString()
        {
            return string.Format("(chatPhoto photo_small:{0} photo_big:{1})", photo_small, photo_big);
        }
    }

    public class MessageEmptyConstructor : Message
    {
        public int id;

        public MessageEmptyConstructor() { }

        public MessageEmptyConstructor(int id)
        {
            this.id = id;
        }

        public override Constructor Constructor
        { get { return Constructor.messageEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x83e5de54);
            writer.Write(id);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messageEmpty id:{0})", id);
        }
    }

    public class MessageConstructor : Message
    {
        public int flags;
        public int id;
        public int? from_id;
        public Peer to_id;
        public Peer fwd_from_id;
        public int? fwd_date;
        public int? reply_to_msg_id;
        public int date;
        public string message;
        public MessageMedia media;
        public ReplyMarkup reply_markup;
        public List<MessageEntity> entities;
        public int? views;

        public MessageConstructor() { }

        public MessageConstructor(int flags, int id, int? from_id, Peer to_id, Peer fwd_from_id, int? fwd_date, int? reply_to_msg_id, int date, string message, MessageMedia media, ReplyMarkup reply_markup, List<MessageEntity> entities, int? views)
        {
            this.flags = flags;
            this.id = id;
            this.from_id = from_id;
            this.to_id = to_id;
            this.fwd_from_id = fwd_from_id;
            this.fwd_date = fwd_date;
            this.reply_to_msg_id = reply_to_msg_id;
            this.date = date;
            this.message = message;
            this.media = media;
            this.reply_markup = reply_markup;
            this.entities = entities;
            this.views = views;
        }

        public override Constructor Constructor
        { get { return Constructor.message; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5ba66c13);
            // Calculate flags value
            flags = 0;
            if (from_id != null) flags += 256;
            if (fwd_from_id != null) flags += 4;
            if (reply_to_msg_id != null) flags += 8;
            if (media != null) flags += 512;
            if (reply_markup != null) flags += 64;
            if (entities != null) flags += 128;
            if (views != null) flags += 1024;

            writer.Write(flags);
            writer.Write(id);
            if (from_id != null)
            {
                writer.Write(from_id.Value);
            }
            to_id.Write(writer);
            if (fwd_from_id != null)
            {
                fwd_from_id.Write(writer);
            }
            if (fwd_date != null)
            {
                writer.Write(fwd_date.Value);
            }
            if (reply_to_msg_id != null)
            {
                writer.Write(reply_to_msg_id.Value);
            }
            writer.Write(date);
            Serializers.String.Write(writer, message);
            if (media != null)
            {
                media.Write(writer);
            }
            if (reply_markup != null)
            {
                reply_markup.Write(writer);
            }
            if (entities != null)
            {
                writer.Write(0x1cb5c415); // vector code
                writer.Write(entities.Count);
                foreach (MessageEntity entities_element in entities)
                    entities_element.Write(writer);
            }
            if (views != null)
            {
                writer.Write(views.Value);
            }
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            id = reader.ReadInt32();
            if ((flags & 256) != 0)
            {
                from_id = reader.ReadInt32();
            }
            to_id = TL.Parse<Peer>(reader);
            if ((flags & 4) != 0)
            {
                fwd_from_id = TL.Parse<Peer>(reader);
            }
            if ((flags & 4) != 0)
            {
                fwd_date = reader.ReadInt32();
            }
            if ((flags & 8) != 0)
            {
                reply_to_msg_id = reader.ReadInt32();
            }
            date = reader.ReadInt32();
            message = Serializers.String.Read(reader);
            if ((flags & 512) != 0)
            {
                media = TL.Parse<MessageMedia>(reader);
            }
            if ((flags & 64) != 0)
            {
                reply_markup = TL.Parse<ReplyMarkup>(reader);
            }
            if ((flags & 128) != 0)
            {
                reader.ReadUInt32(); // vector code
                int entities_count = reader.ReadInt32();
                entities = new List<MessageEntity>(entities_count);
                for (int entities_index = 0; entities_index < entities_count; entities_index++)
                    entities.Add(TL.Parse<MessageEntity>(reader));
            }
            if ((flags & 1024) != 0)
            {
                views = reader.ReadInt32();
            }
        }

        public override string ToString()
        {
            return string.Format("(message flags:{0} id:{1} from_id:{2} to_id:{3} fwd_from_id:{4} fwd_date:{5} reply_to_msg_id:{6} date:{7} message:{8} media:{9} reply_markup:{10} entities:{11} views:{12})", flags, id, from_id, to_id, fwd_from_id, fwd_date, reply_to_msg_id, date, message, media, reply_markup, entities, views);
        }
    }

    public class MessageServiceConstructor : Message
    {
        public int flags;
        public int id;
        public int? from_id;
        public Peer to_id;
        public int date;
        public MessageAction action;

        public MessageServiceConstructor() { }

        public MessageServiceConstructor(int flags, int id, int? from_id, Peer to_id, int date, MessageAction action)
        {
            this.flags = flags;
            this.id = id;
            this.from_id = from_id;
            this.to_id = to_id;
            this.date = date;
            this.action = action;
        }

        public override Constructor Constructor
        { get { return Constructor.messageService; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc06b9607);
            // Calculate flags value
            flags = 0;
            if (from_id != null) flags += 256;

            writer.Write(flags);
            writer.Write(id);
            if (from_id != null)
            {
                writer.Write(from_id.Value);
            }
            to_id.Write(writer);
            writer.Write(date);
            action.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            id = reader.ReadInt32();
            if ((flags & 256) != 0)
            {
                from_id = reader.ReadInt32();
            }
            to_id = TL.Parse<Peer>(reader);
            date = reader.ReadInt32();
            action = TL.Parse<MessageAction>(reader);
        }

        public override string ToString()
        {
            return string.Format("(messageService flags:{0} id:{1} from_id:{2} to_id:{3} date:{4} action:{5})", flags, id, from_id, to_id, date, action);
        }
    }

    public class MessageMediaEmptyConstructor : MessageMedia
    {
        public MessageMediaEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.messageMediaEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x3ded6320);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(messageMediaEmpty)");
        }
    }

    public class MessageMediaPhotoConstructor : MessageMedia
    {
        public Photo photo;
        public string caption;

        public MessageMediaPhotoConstructor() { }

        public MessageMediaPhotoConstructor(Photo photo, string caption)
        {
            this.photo = photo;
            this.caption = caption;
        }

        public override Constructor Constructor
        { get { return Constructor.messageMediaPhoto; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x3d8ce53d);
            photo.Write(writer);
            Serializers.String.Write(writer, caption);
        }

        public override void Read(BinaryReader reader)
        {
            photo = TL.Parse<Photo>(reader);
            caption = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(messageMediaPhoto photo:{0} caption:{1})", photo, caption);
        }
    }

    public class MessageMediaVideoConstructor : MessageMedia
    {
        public Video video;
        public string caption;

        public MessageMediaVideoConstructor() { }

        public MessageMediaVideoConstructor(Video video, string caption)
        {
            this.video = video;
            this.caption = caption;
        }

        public override Constructor Constructor
        { get { return Constructor.messageMediaVideo; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5bcf1675);
            video.Write(writer);
            Serializers.String.Write(writer, caption);
        }

        public override void Read(BinaryReader reader)
        {
            video = TL.Parse<Video>(reader);
            caption = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(messageMediaVideo video:{0} caption:{1})", video, caption);
        }
    }

    public class MessageMediaGeoConstructor : MessageMedia
    {
        public GeoPoint geo;

        public MessageMediaGeoConstructor() { }

        public MessageMediaGeoConstructor(GeoPoint geo)
        {
            this.geo = geo;
        }

        public override Constructor Constructor
        { get { return Constructor.messageMediaGeo; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x56e0d474);
            geo.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            geo = TL.Parse<GeoPoint>(reader);
        }

        public override string ToString()
        {
            return string.Format("(messageMediaGeo geo:{0})", geo);
        }
    }

    public class MessageMediaContactConstructor : MessageMedia
    {
        public string phone_number;
        public string first_name;
        public string last_name;
        public int user_id;

        public MessageMediaContactConstructor() { }

        public MessageMediaContactConstructor(string phone_number, string first_name, string last_name, int user_id)
        {
            this.phone_number = phone_number;
            this.first_name = first_name;
            this.last_name = last_name;
            this.user_id = user_id;
        }

        public override Constructor Constructor
        { get { return Constructor.messageMediaContact; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5e7d2f39);
            Serializers.String.Write(writer, phone_number);
            Serializers.String.Write(writer, first_name);
            Serializers.String.Write(writer, last_name);
            writer.Write(user_id);
        }

        public override void Read(BinaryReader reader)
        {
            phone_number = Serializers.String.Read(reader);
            first_name = Serializers.String.Read(reader);
            last_name = Serializers.String.Read(reader);
            user_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messageMediaContact phone_number:{0} first_name:{1} last_name:{2} user_id:{3})", phone_number, first_name, last_name, user_id);
        }
    }

    public class MessageMediaUnsupportedConstructor : MessageMedia
    {
        public MessageMediaUnsupportedConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.messageMediaUnsupported; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9f84f49e);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(messageMediaUnsupported)");
        }
    }

    public class MessageMediaDocumentConstructor : MessageMedia
    {
        public Document document;

        public MessageMediaDocumentConstructor() { }

        public MessageMediaDocumentConstructor(Document document)
        {
            this.document = document;
        }

        public override Constructor Constructor
        { get { return Constructor.messageMediaDocument; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2fda2204);
            document.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            document = TL.Parse<Document>(reader);
        }

        public override string ToString()
        {
            return string.Format("(messageMediaDocument document:{0})", document);
        }
    }

    public class MessageMediaAudioConstructor : MessageMedia
    {
        public Audio audio;

        public MessageMediaAudioConstructor() { }

        public MessageMediaAudioConstructor(Audio audio)
        {
            this.audio = audio;
        }

        public override Constructor Constructor
        { get { return Constructor.messageMediaAudio; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc6b68300);
            audio.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            audio = TL.Parse<Audio>(reader);
        }

        public override string ToString()
        {
            return string.Format("(messageMediaAudio audio:{0})", audio);
        }
    }

    public class MessageMediaWebPageConstructor : MessageMedia
    {
        public WebPage webpage;

        public MessageMediaWebPageConstructor() { }

        public MessageMediaWebPageConstructor(WebPage webpage)
        {
            this.webpage = webpage;
        }

        public override Constructor Constructor
        { get { return Constructor.messageMediaWebPage; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa32dd600);
            webpage.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            webpage = TL.Parse<WebPage>(reader);
        }

        public override string ToString()
        {
            return string.Format("(messageMediaWebPage webpage:{0})", webpage);
        }
    }

    public class MessageMediaVenueConstructor : MessageMedia
    {
        public GeoPoint geo;
        public string title;
        public string address;
        public string provider;
        public string venue_id;

        public MessageMediaVenueConstructor() { }

        public MessageMediaVenueConstructor(GeoPoint geo, string title, string address, string provider, string venue_id)
        {
            this.geo = geo;
            this.title = title;
            this.address = address;
            this.provider = provider;
            this.venue_id = venue_id;
        }

        public override Constructor Constructor
        { get { return Constructor.messageMediaVenue; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7912b71f);
            geo.Write(writer);
            Serializers.String.Write(writer, title);
            Serializers.String.Write(writer, address);
            Serializers.String.Write(writer, provider);
            Serializers.String.Write(writer, venue_id);
        }

        public override void Read(BinaryReader reader)
        {
            geo = TL.Parse<GeoPoint>(reader);
            title = Serializers.String.Read(reader);
            address = Serializers.String.Read(reader);
            provider = Serializers.String.Read(reader);
            venue_id = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(messageMediaVenue geo:{0} title:{1} address:{2} provider:{3} venue_id:{4})", geo, title, address, provider, venue_id);
        }
    }

    public class MessageActionEmptyConstructor : MessageAction
    {
        public MessageActionEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.messageActionEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb6aef7b0);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(messageActionEmpty)");
        }
    }

    public class MessageActionChatCreateConstructor : MessageAction
    {
        public string title;
        public List<int> users;

        public MessageActionChatCreateConstructor() { }

        public MessageActionChatCreateConstructor(string title, List<int> users)
        {
            this.title = title;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.messageActionChatCreate; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa6638b9a);
            Serializers.String.Write(writer, title);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (int users_element in users)
                writer.Write(users_element);
        }

        public override void Read(BinaryReader reader)
        {
            title = Serializers.String.Read(reader);
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<int>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(reader.ReadInt32());
        }

        public override string ToString()
        {
            return string.Format("(messageActionChatCreate title:{0} users:{1})", title, users);
        }
    }

    public class MessageActionChatEditTitleConstructor : MessageAction
    {
        public string title;

        public MessageActionChatEditTitleConstructor() { }

        public MessageActionChatEditTitleConstructor(string title)
        {
            this.title = title;
        }

        public override Constructor Constructor
        { get { return Constructor.messageActionChatEditTitle; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb5a1ce5a);
            Serializers.String.Write(writer, title);
        }

        public override void Read(BinaryReader reader)
        {
            title = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(messageActionChatEditTitle title:{0})", title);
        }
    }

    public class MessageActionChatEditPhotoConstructor : MessageAction
    {
        public Photo photo;

        public MessageActionChatEditPhotoConstructor() { }

        public MessageActionChatEditPhotoConstructor(Photo photo)
        {
            this.photo = photo;
        }

        public override Constructor Constructor
        { get { return Constructor.messageActionChatEditPhoto; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7fcb13a8);
            photo.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            photo = TL.Parse<Photo>(reader);
        }

        public override string ToString()
        {
            return string.Format("(messageActionChatEditPhoto photo:{0})", photo);
        }
    }

    public class MessageActionChatDeletePhotoConstructor : MessageAction
    {
        public MessageActionChatDeletePhotoConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.messageActionChatDeletePhoto; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x95e3fbef);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(messageActionChatDeletePhoto)");
        }
    }

    public class MessageActionChatAddUserConstructor : MessageAction
    {
        public int user_id;

        public MessageActionChatAddUserConstructor() { }

        public MessageActionChatAddUserConstructor(int user_id)
        {
            this.user_id = user_id;
        }

        public override Constructor Constructor
        { get { return Constructor.messageActionChatAddUser; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5e3cfc4b);
            writer.Write(user_id);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messageActionChatAddUser user_id:{0})", user_id);
        }
    }

    public class MessageActionChatDeleteUserConstructor : MessageAction
    {
        public int user_id;

        public MessageActionChatDeleteUserConstructor() { }

        public MessageActionChatDeleteUserConstructor(int user_id)
        {
            this.user_id = user_id;
        }

        public override Constructor Constructor
        { get { return Constructor.messageActionChatDeleteUser; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb2ae9b0c);
            writer.Write(user_id);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messageActionChatDeleteUser user_id:{0})", user_id);
        }
    }

    public class MessageActionChatJoinedByLinkConstructor : MessageAction
    {
        public int inviter_id;

        public MessageActionChatJoinedByLinkConstructor() { }

        public MessageActionChatJoinedByLinkConstructor(int inviter_id)
        {
            this.inviter_id = inviter_id;
        }

        public override Constructor Constructor
        { get { return Constructor.messageActionChatJoinedByLink; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf89cf5e8);
            writer.Write(inviter_id);
        }

        public override void Read(BinaryReader reader)
        {
            inviter_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messageActionChatJoinedByLink inviter_id:{0})", inviter_id);
        }
    }

    public class MessageActionChannelCreateConstructor : MessageAction
    {
        public string title;

        public MessageActionChannelCreateConstructor() { }

        public MessageActionChannelCreateConstructor(string title)
        {
            this.title = title;
        }

        public override Constructor Constructor
        { get { return Constructor.messageActionChannelCreate; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x95d2ac92);
            Serializers.String.Write(writer, title);
        }

        public override void Read(BinaryReader reader)
        {
            title = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(messageActionChannelCreate title:{0})", title);
        }
    }

    public class DialogConstructor : Dialog
    {
        public Peer peer;
        public int top_message;
        public int read_inbox_max_id;
        public int unread_count;
        public PeerNotifySettings notify_settings;

        public DialogConstructor() { }

        public DialogConstructor(Peer peer, int top_message, int read_inbox_max_id, int unread_count, PeerNotifySettings notify_settings)
        {
            this.peer = peer;
            this.top_message = top_message;
            this.read_inbox_max_id = read_inbox_max_id;
            this.unread_count = unread_count;
            this.notify_settings = notify_settings;
        }

        public override Constructor Constructor
        { get { return Constructor.dialog; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc1dd804a);
            peer.Write(writer);
            writer.Write(top_message);
            writer.Write(read_inbox_max_id);
            writer.Write(unread_count);
            notify_settings.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            peer = TL.Parse<Peer>(reader);
            top_message = reader.ReadInt32();
            read_inbox_max_id = reader.ReadInt32();
            unread_count = reader.ReadInt32();
            notify_settings = TL.Parse<PeerNotifySettings>(reader);
        }

        public override string ToString()
        {
            return string.Format("(dialog peer:{0} top_message:{1} read_inbox_max_id:{2} unread_count:{3} notify_settings:{4})", peer, top_message, read_inbox_max_id, unread_count, notify_settings);
        }
    }

    public class DialogChannelConstructor : Dialog
    {
        public Peer peer;
        public int top_message;
        public int top_important_message;
        public int read_inbox_max_id;
        public int unread_count;
        public int unread_important_count;
        public PeerNotifySettings notify_settings;
        public int pts;

        public DialogChannelConstructor() { }

        public DialogChannelConstructor(Peer peer, int top_message, int top_important_message, int read_inbox_max_id, int unread_count, int unread_important_count, PeerNotifySettings notify_settings, int pts)
        {
            this.peer = peer;
            this.top_message = top_message;
            this.top_important_message = top_important_message;
            this.read_inbox_max_id = read_inbox_max_id;
            this.unread_count = unread_count;
            this.unread_important_count = unread_important_count;
            this.notify_settings = notify_settings;
            this.pts = pts;
        }

        public override Constructor Constructor
        { get { return Constructor.dialogChannel; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5b8496b2);
            peer.Write(writer);
            writer.Write(top_message);
            writer.Write(top_important_message);
            writer.Write(read_inbox_max_id);
            writer.Write(unread_count);
            writer.Write(unread_important_count);
            notify_settings.Write(writer);
            writer.Write(pts);
        }

        public override void Read(BinaryReader reader)
        {
            peer = TL.Parse<Peer>(reader);
            top_message = reader.ReadInt32();
            top_important_message = reader.ReadInt32();
            read_inbox_max_id = reader.ReadInt32();
            unread_count = reader.ReadInt32();
            unread_important_count = reader.ReadInt32();
            notify_settings = TL.Parse<PeerNotifySettings>(reader);
            pts = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(dialogChannel peer:{0} top_message:{1} top_important_message:{2} read_inbox_max_id:{3} unread_count:{4} unread_important_count:{5} notify_settings:{6} pts:{7})", peer, top_message, top_important_message, read_inbox_max_id, unread_count, unread_important_count, notify_settings, pts);
        }
    }

    public class PhotoEmptyConstructor : Photo
    {
        public long id;

        public PhotoEmptyConstructor() { }

        public PhotoEmptyConstructor(long id)
        {
            this.id = id;
        }

        public override Constructor Constructor
        { get { return Constructor.photoEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2331b22d);
            writer.Write(id);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(photoEmpty id:{0})", id);
        }
    }

    public class PhotoConstructor : Photo
    {
        public long id;
        public long access_hash;
        public int date;
        public List<PhotoSize> sizes;

        public PhotoConstructor() { }

        public PhotoConstructor(long id, long access_hash, int date, List<PhotoSize> sizes)
        {
            this.id = id;
            this.access_hash = access_hash;
            this.date = date;
            this.sizes = sizes;
        }

        public override Constructor Constructor
        { get { return Constructor.photo; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xcded42fe);
            writer.Write(id);
            writer.Write(access_hash);
            writer.Write(date);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(sizes.Count);
            foreach (PhotoSize sizes_element in sizes)
                sizes_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            access_hash = reader.ReadInt64();
            date = reader.ReadInt32();
            reader.ReadUInt32(); // vector code
            int sizes_count = reader.ReadInt32();
            sizes = new List<PhotoSize>(sizes_count);
            for (int sizes_index = 0; sizes_index < sizes_count; sizes_index++)
                sizes.Add(TL.Parse<PhotoSize>(reader));
        }

        public override string ToString()
        {
            return string.Format("(photo id:{0} access_hash:{1} date:{2} sizes:{3})", id, access_hash, date, sizes);
        }
    }

    public class PhotoSizeEmptyConstructor : PhotoSize
    {
        public string type;

        public PhotoSizeEmptyConstructor() { }

        public PhotoSizeEmptyConstructor(string type)
        {
            this.type = type;
        }

        public override Constructor Constructor
        { get { return Constructor.photoSizeEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe17e23c);
            Serializers.String.Write(writer, type);
        }

        public override void Read(BinaryReader reader)
        {
            type = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(photoSizeEmpty type:{0})", type);
        }
    }

    public class PhotoSizeConstructor : PhotoSize
    {
        public string type;
        public FileLocation location;
        public int w;
        public int h;
        public int size;

        public PhotoSizeConstructor() { }

        public PhotoSizeConstructor(string type, FileLocation location, int w, int h, int size)
        {
            this.type = type;
            this.location = location;
            this.w = w;
            this.h = h;
            this.size = size;
        }

        public override Constructor Constructor
        { get { return Constructor.photoSize; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x77bfb61b);
            Serializers.String.Write(writer, type);
            location.Write(writer);
            writer.Write(w);
            writer.Write(h);
            writer.Write(size);
        }

        public override void Read(BinaryReader reader)
        {
            type = Serializers.String.Read(reader);
            location = TL.Parse<FileLocation>(reader);
            w = reader.ReadInt32();
            h = reader.ReadInt32();
            size = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(photoSize type:{0} location:{1} w:{2} h:{3} size:{4})", type, location, w, h, size);
        }
    }

    public class PhotoCachedSizeConstructor : PhotoSize
    {
        public string type;
        public FileLocation location;
        public int w;
        public int h;
        public byte[] bytes;

        public PhotoCachedSizeConstructor() { }

        public PhotoCachedSizeConstructor(string type, FileLocation location, int w, int h, byte[] bytes)
        {
            this.type = type;
            this.location = location;
            this.w = w;
            this.h = h;
            this.bytes = bytes;
        }

        public override Constructor Constructor
        { get { return Constructor.photoCachedSize; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe9a734fa);
            Serializers.String.Write(writer, type);
            location.Write(writer);
            writer.Write(w);
            writer.Write(h);
            Serializers.Bytes.Write(writer, bytes);
        }

        public override void Read(BinaryReader reader)
        {
            type = Serializers.String.Read(reader);
            location = TL.Parse<FileLocation>(reader);
            w = reader.ReadInt32();
            h = reader.ReadInt32();
            bytes = Serializers.Bytes.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(photoCachedSize type:{0} location:{1} w:{2} h:{3} bytes:{4})", type, location, w, h, bytes);
        }
    }

    public class VideoEmptyConstructor : Video
    {
        public long id;

        public VideoEmptyConstructor() { }

        public VideoEmptyConstructor(long id)
        {
            this.id = id;
        }

        public override Constructor Constructor
        { get { return Constructor.videoEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc10658a8);
            writer.Write(id);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(videoEmpty id:{0})", id);
        }
    }

    public class VideoConstructor : Video
    {
        public long id;
        public long access_hash;
        public int date;
        public int duration;
        public string mime_type;
        public int size;
        public PhotoSize thumb;
        public int dc_id;
        public int w;
        public int h;

        public VideoConstructor() { }

        public VideoConstructor(long id, long access_hash, int date, int duration, string mime_type, int size, PhotoSize thumb, int dc_id, int w, int h)
        {
            this.id = id;
            this.access_hash = access_hash;
            this.date = date;
            this.duration = duration;
            this.mime_type = mime_type;
            this.size = size;
            this.thumb = thumb;
            this.dc_id = dc_id;
            this.w = w;
            this.h = h;
        }

        public override Constructor Constructor
        { get { return Constructor.video; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf72887d3);
            writer.Write(id);
            writer.Write(access_hash);
            writer.Write(date);
            writer.Write(duration);
            Serializers.String.Write(writer, mime_type);
            writer.Write(size);
            thumb.Write(writer);
            writer.Write(dc_id);
            writer.Write(w);
            writer.Write(h);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            access_hash = reader.ReadInt64();
            date = reader.ReadInt32();
            duration = reader.ReadInt32();
            mime_type = Serializers.String.Read(reader);
            size = reader.ReadInt32();
            thumb = TL.Parse<PhotoSize>(reader);
            dc_id = reader.ReadInt32();
            w = reader.ReadInt32();
            h = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(video id:{0} access_hash:{1} date:{2} duration:{3} mime_type:{4} size:{5} thumb:{6} dc_id:{7} w:{8} h:{9})", id, access_hash, date, duration, mime_type, size, thumb, dc_id, w, h);
        }
    }

    public class GeoPointEmptyConstructor : GeoPoint
    {
        public GeoPointEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.geoPointEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1117dd5f);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(geoPointEmpty)");
        }
    }

    public class GeoPointConstructor : GeoPoint
    {
        public double @long;
        public double lat;

        public GeoPointConstructor() { }

        public GeoPointConstructor(double @long, double lat)
        {
            this.@long = @long;
            this.lat = lat;
        }

        public override Constructor Constructor
        { get { return Constructor.geoPoint; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2049d70c);
            writer.Write(@long);
            writer.Write(lat);
        }

        public override void Read(BinaryReader reader)
        {
            @long = reader.ReadDouble();
            lat = reader.ReadDouble();
        }

        public override string ToString()
        {
            return string.Format("(geoPoint @long:{0} lat:{1})", @long, lat);
        }
    }

    public class Auth_checkedPhoneConstructor : auth_CheckedPhone
    {
        public bool phone_registered;

        public Auth_checkedPhoneConstructor() { }

        public Auth_checkedPhoneConstructor(bool phone_registered)
        {
            this.phone_registered = phone_registered;
        }

        public override Constructor Constructor
        { get { return Constructor.auth_checkedPhone; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x811ea28e);
            writer.Write(phone_registered ? 0x997275b5 : 0xbc799737);
        }

        public override void Read(BinaryReader reader)
        {
            phone_registered = reader.ReadUInt32() == 0x997275b5;
        }

        public override string ToString()
        {
            return string.Format("(auth_checkedPhone phone_registered:{0})", phone_registered);
        }
    }

    public class Auth_sentCodeConstructor : auth_SentCode
    {
        public bool phone_registered;
        public string phone_code_hash;
        public int send_call_timeout;
        public bool is_password;

        public Auth_sentCodeConstructor() { }

        public Auth_sentCodeConstructor(bool phone_registered, string phone_code_hash, int send_call_timeout, bool is_password)
        {
            this.phone_registered = phone_registered;
            this.phone_code_hash = phone_code_hash;
            this.send_call_timeout = send_call_timeout;
            this.is_password = is_password;
        }

        public override Constructor Constructor
        { get { return Constructor.auth_sentCode; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xefed51d9);
            writer.Write(phone_registered ? 0x997275b5 : 0xbc799737);
            Serializers.String.Write(writer, phone_code_hash);
            writer.Write(send_call_timeout);
            writer.Write(is_password ? 0x997275b5 : 0xbc799737);
        }

        public override void Read(BinaryReader reader)
        {
            phone_registered = reader.ReadUInt32() == 0x997275b5;
            phone_code_hash = Serializers.String.Read(reader);
            send_call_timeout = reader.ReadInt32();
            is_password = reader.ReadUInt32() == 0x997275b5;
        }

        public override string ToString()
        {
            return string.Format("(auth_sentCode phone_registered:{0} phone_code_hash:{1} send_call_timeout:{2} is_password:{3})", phone_registered, phone_code_hash, send_call_timeout, is_password);
        }
    }

    public class Auth_sentAppCodeConstructor : auth_SentCode
    {
        public bool phone_registered;
        public string phone_code_hash;
        public int send_call_timeout;
        public bool is_password;

        public Auth_sentAppCodeConstructor() { }

        public Auth_sentAppCodeConstructor(bool phone_registered, string phone_code_hash, int send_call_timeout, bool is_password)
        {
            this.phone_registered = phone_registered;
            this.phone_code_hash = phone_code_hash;
            this.send_call_timeout = send_call_timeout;
            this.is_password = is_password;
        }

        public override Constructor Constructor
        { get { return Constructor.auth_sentAppCode; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe325edcf);
            writer.Write(phone_registered ? 0x997275b5 : 0xbc799737);
            Serializers.String.Write(writer, phone_code_hash);
            writer.Write(send_call_timeout);
            writer.Write(is_password ? 0x997275b5 : 0xbc799737);
        }

        public override void Read(BinaryReader reader)
        {
            phone_registered = reader.ReadUInt32() == 0x997275b5;
            phone_code_hash = Serializers.String.Read(reader);
            send_call_timeout = reader.ReadInt32();
            is_password = reader.ReadUInt32() == 0x997275b5;
        }

        public override string ToString()
        {
            return string.Format("(auth_sentAppCode phone_registered:{0} phone_code_hash:{1} send_call_timeout:{2} is_password:{3})", phone_registered, phone_code_hash, send_call_timeout, is_password);
        }
    }

    public class Auth_authorizationConstructor : auth_Authorization
    {
        public User user;

        public Auth_authorizationConstructor() { }

        public Auth_authorizationConstructor(User user)
        {
            this.user = user;
        }

        public override Constructor Constructor
        { get { return Constructor.auth_authorization; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xff036af1);
            user.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            user = TL.Parse<User>(reader);
        }

        public override string ToString()
        {
            return string.Format("(auth_authorization user:{0})", user);
        }
    }

    public class Auth_exportedAuthorizationConstructor : auth_ExportedAuthorization
    {
        public int id;
        public byte[] bytes;

        public Auth_exportedAuthorizationConstructor() { }

        public Auth_exportedAuthorizationConstructor(int id, byte[] bytes)
        {
            this.id = id;
            this.bytes = bytes;
        }

        public override Constructor Constructor
        { get { return Constructor.auth_exportedAuthorization; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xdf969c2d);
            writer.Write(id);
            Serializers.Bytes.Write(writer, bytes);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt32();
            bytes = Serializers.Bytes.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(auth_exportedAuthorization id:{0} bytes:{1})", id, bytes);
        }
    }

    public class InputNotifyPeerConstructor : InputNotifyPeer
    {
        public InputPeer peer;

        public InputNotifyPeerConstructor() { }

        public InputNotifyPeerConstructor(InputPeer peer)
        {
            this.peer = peer;
        }

        public override Constructor Constructor
        { get { return Constructor.inputNotifyPeer; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb8bc5b0c);
            peer.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            peer = TL.Parse<InputPeer>(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputNotifyPeer peer:{0})", peer);
        }
    }

    public class InputNotifyUsersConstructor : InputNotifyPeer
    {
        public InputNotifyUsersConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputNotifyUsers; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x193b4417);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputNotifyUsers)");
        }
    }

    public class InputNotifyChatsConstructor : InputNotifyPeer
    {
        public InputNotifyChatsConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputNotifyChats; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4a95e84e);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputNotifyChats)");
        }
    }

    public class InputNotifyAllConstructor : InputNotifyPeer
    {
        public InputNotifyAllConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputNotifyAll; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa429b886);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputNotifyAll)");
        }
    }

    public class InputPeerNotifyEventsEmptyConstructor : InputPeerNotifyEvents
    {
        public InputPeerNotifyEventsEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputPeerNotifyEventsEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf03064d8);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputPeerNotifyEventsEmpty)");
        }
    }

    public class InputPeerNotifyEventsAllConstructor : InputPeerNotifyEvents
    {
        public InputPeerNotifyEventsAllConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputPeerNotifyEventsAll; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe86a2c74);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputPeerNotifyEventsAll)");
        }
    }

    public class InputPeerNotifySettingsConstructor : InputPeerNotifySettings
    {
        public int mute_until;
        public string sound;
        public bool show_previews;
        public int events_mask;

        public InputPeerNotifySettingsConstructor() { }

        public InputPeerNotifySettingsConstructor(int mute_until, string sound, bool show_previews, int events_mask)
        {
            this.mute_until = mute_until;
            this.sound = sound;
            this.show_previews = show_previews;
            this.events_mask = events_mask;
        }

        public override Constructor Constructor
        { get { return Constructor.inputPeerNotifySettings; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x46a2ce98);
            writer.Write(mute_until);
            Serializers.String.Write(writer, sound);
            writer.Write(show_previews ? 0x997275b5 : 0xbc799737);
            writer.Write(events_mask);
        }

        public override void Read(BinaryReader reader)
        {
            mute_until = reader.ReadInt32();
            sound = Serializers.String.Read(reader);
            show_previews = reader.ReadUInt32() == 0x997275b5;
            events_mask = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(inputPeerNotifySettings mute_until:{0} sound:{1} show_previews:{2} events_mask:{3})", mute_until, sound, show_previews, events_mask);
        }
    }

    public class PeerNotifyEventsEmptyConstructor : PeerNotifyEvents
    {
        public PeerNotifyEventsEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.peerNotifyEventsEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xadd53cb3);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(peerNotifyEventsEmpty)");
        }
    }

    public class PeerNotifyEventsAllConstructor : PeerNotifyEvents
    {
        public PeerNotifyEventsAllConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.peerNotifyEventsAll; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6d1ded88);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(peerNotifyEventsAll)");
        }
    }

    public class PeerNotifySettingsEmptyConstructor : PeerNotifySettings
    {
        public PeerNotifySettingsEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.peerNotifySettingsEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x70a68512);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(peerNotifySettingsEmpty)");
        }
    }

    public class PeerNotifySettingsConstructor : PeerNotifySettings
    {
        public int mute_until;
        public string sound;
        public bool show_previews;
        public int events_mask;

        public PeerNotifySettingsConstructor() { }

        public PeerNotifySettingsConstructor(int mute_until, string sound, bool show_previews, int events_mask)
        {
            this.mute_until = mute_until;
            this.sound = sound;
            this.show_previews = show_previews;
            this.events_mask = events_mask;
        }

        public override Constructor Constructor
        { get { return Constructor.peerNotifySettings; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x8d5e11ee);
            writer.Write(mute_until);
            Serializers.String.Write(writer, sound);
            writer.Write(show_previews ? 0x997275b5 : 0xbc799737);
            writer.Write(events_mask);
        }

        public override void Read(BinaryReader reader)
        {
            mute_until = reader.ReadInt32();
            sound = Serializers.String.Read(reader);
            show_previews = reader.ReadUInt32() == 0x997275b5;
            events_mask = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(peerNotifySettings mute_until:{0} sound:{1} show_previews:{2} events_mask:{3})", mute_until, sound, show_previews, events_mask);
        }
    }

    public class WallPaperConstructor : WallPaper
    {
        public int id;
        public string title;
        public List<PhotoSize> sizes;
        public int color;

        public WallPaperConstructor() { }

        public WallPaperConstructor(int id, string title, List<PhotoSize> sizes, int color)
        {
            this.id = id;
            this.title = title;
            this.sizes = sizes;
            this.color = color;
        }

        public override Constructor Constructor
        { get { return Constructor.wallPaper; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xccb03657);
            writer.Write(id);
            Serializers.String.Write(writer, title);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(sizes.Count);
            foreach (PhotoSize sizes_element in sizes)
                sizes_element.Write(writer);
            writer.Write(color);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt32();
            title = Serializers.String.Read(reader);
            reader.ReadUInt32(); // vector code
            int sizes_count = reader.ReadInt32();
            sizes = new List<PhotoSize>(sizes_count);
            for (int sizes_index = 0; sizes_index < sizes_count; sizes_index++)
                sizes.Add(TL.Parse<PhotoSize>(reader));
            color = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(wallPaper id:{0} title:{1} sizes:{2} color:{3})", id, title, sizes, color);
        }
    }

    public class WallPaperSolidConstructor : WallPaper
    {
        public int id;
        public string title;
        public int bg_color;
        public int color;

        public WallPaperSolidConstructor() { }

        public WallPaperSolidConstructor(int id, string title, int bg_color, int color)
        {
            this.id = id;
            this.title = title;
            this.bg_color = bg_color;
            this.color = color;
        }

        public override Constructor Constructor
        { get { return Constructor.wallPaperSolid; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x63117f24);
            writer.Write(id);
            Serializers.String.Write(writer, title);
            writer.Write(bg_color);
            writer.Write(color);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt32();
            title = Serializers.String.Read(reader);
            bg_color = reader.ReadInt32();
            color = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(wallPaperSolid id:{0} title:{1} bg_color:{2} color:{3})", id, title, bg_color, color);
        }
    }

    public class UserFullConstructor : UserFull
    {
        public User user;
        public contacts_Link link;
        public Photo profile_photo;
        public PeerNotifySettings notify_settings;
        public bool blocked;
        public BotInfo bot_info;

        public UserFullConstructor() { }

        public UserFullConstructor(User user, contacts_Link link, Photo profile_photo, PeerNotifySettings notify_settings, bool blocked, BotInfo bot_info)
        {
            this.user = user;
            this.link = link;
            this.profile_photo = profile_photo;
            this.notify_settings = notify_settings;
            this.blocked = blocked;
            this.bot_info = bot_info;
        }

        public override Constructor Constructor
        { get { return Constructor.userFull; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5a89ac5b);
            user.Write(writer);
            link.Write(writer);
            profile_photo.Write(writer);
            notify_settings.Write(writer);
            writer.Write(blocked ? 0x997275b5 : 0xbc799737);
            bot_info.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            user = TL.Parse<User>(reader);
            link = TL.Parse<contacts_Link>(reader);
            profile_photo = TL.Parse<Photo>(reader);
            notify_settings = TL.Parse<PeerNotifySettings>(reader);
            blocked = reader.ReadUInt32() == 0x997275b5;
            bot_info = TL.Parse<BotInfo>(reader);
        }

        public override string ToString()
        {
            return string.Format("(userFull user:{0} link:{1} profile_photo:{2} notify_settings:{3} blocked:{4} bot_info:{5})", user, link, profile_photo, notify_settings, blocked, bot_info);
        }
    }

    public class ContactConstructor : Contact
    {
        public int user_id;
        public bool mutual;

        public ContactConstructor() { }

        public ContactConstructor(int user_id, bool mutual)
        {
            this.user_id = user_id;
            this.mutual = mutual;
        }

        public override Constructor Constructor
        { get { return Constructor.contact; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf911c994);
            writer.Write(user_id);
            writer.Write(mutual ? 0x997275b5 : 0xbc799737);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            mutual = reader.ReadUInt32() == 0x997275b5;
        }

        public override string ToString()
        {
            return string.Format("(contact user_id:{0} mutual:{1})", user_id, mutual);
        }
    }

    public class ImportedContactConstructor : ImportedContact
    {
        public int user_id;
        public long client_id;

        public ImportedContactConstructor() { }

        public ImportedContactConstructor(int user_id, long client_id)
        {
            this.user_id = user_id;
            this.client_id = client_id;
        }

        public override Constructor Constructor
        { get { return Constructor.importedContact; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd0028438);
            writer.Write(user_id);
            writer.Write(client_id);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            client_id = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(importedContact user_id:{0} client_id:{1})", user_id, client_id);
        }
    }

    public class ContactBlockedConstructor : ContactBlocked
    {
        public int user_id;
        public int date;

        public ContactBlockedConstructor() { }

        public ContactBlockedConstructor(int user_id, int date)
        {
            this.user_id = user_id;
            this.date = date;
        }

        public override Constructor Constructor
        { get { return Constructor.contactBlocked; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x561bc879);
            writer.Write(user_id);
            writer.Write(date);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(contactBlocked user_id:{0} date:{1})", user_id, date);
        }
    }

    public class ContactSuggestedConstructor : ContactSuggested
    {
        public int user_id;
        public int mutual_contacts;

        public ContactSuggestedConstructor() { }

        public ContactSuggestedConstructor(int user_id, int mutual_contacts)
        {
            this.user_id = user_id;
            this.mutual_contacts = mutual_contacts;
        }

        public override Constructor Constructor
        { get { return Constructor.contactSuggested; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x3de191a1);
            writer.Write(user_id);
            writer.Write(mutual_contacts);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            mutual_contacts = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(contactSuggested user_id:{0} mutual_contacts:{1})", user_id, mutual_contacts);
        }
    }

    public class ContactStatusConstructor : ContactStatus
    {
        public int user_id;
        public UserStatus status;

        public ContactStatusConstructor() { }

        public ContactStatusConstructor(int user_id, UserStatus status)
        {
            this.user_id = user_id;
            this.status = status;
        }

        public override Constructor Constructor
        { get { return Constructor.contactStatus; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd3680c61);
            writer.Write(user_id);
            status.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            status = TL.Parse<UserStatus>(reader);
        }

        public override string ToString()
        {
            return string.Format("(contactStatus user_id:{0} status:{1})", user_id, status);
        }
    }

    public class Contacts_linkConstructor : contacts_Link
    {
        public ContactLink my_link;
        public ContactLink foreign_link;
        public User user;

        public Contacts_linkConstructor() { }

        public Contacts_linkConstructor(ContactLink my_link, ContactLink foreign_link, User user)
        {
            this.my_link = my_link;
            this.foreign_link = foreign_link;
            this.user = user;
        }

        public override Constructor Constructor
        { get { return Constructor.contacts_link; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x3ace484c);
            my_link.Write(writer);
            foreign_link.Write(writer);
            user.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            my_link = TL.Parse<ContactLink>(reader);
            foreign_link = TL.Parse<ContactLink>(reader);
            user = TL.Parse<User>(reader);
        }

        public override string ToString()
        {
            return string.Format("(contacts_link my_link:{0} foreign_link:{1} user:{2})", my_link, foreign_link, user);
        }
    }

    public class Contacts_contactsNotModifiedConstructor : contacts_Contacts
    {
        public Contacts_contactsNotModifiedConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.contacts_contactsNotModified; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb74ba9d2);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(contacts_contactsNotModified)");
        }
    }

    public class Contacts_contactsConstructor : contacts_Contacts
    {
        public List<Contact> contacts;
        public List<User> users;

        public Contacts_contactsConstructor() { }

        public Contacts_contactsConstructor(List<Contact> contacts, List<User> users)
        {
            this.contacts = contacts;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.contacts_contacts; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6f8b8cb2);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(contacts.Count);
            foreach (Contact contacts_element in contacts)
                contacts_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int contacts_count = reader.ReadInt32();
            contacts = new List<Contact>(contacts_count);
            for (int contacts_index = 0; contacts_index < contacts_count; contacts_index++)
                contacts.Add(TL.Parse<Contact>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(contacts_contacts contacts:{0} users:{1})", contacts, users);
        }
    }

    public class Contacts_importedContactsConstructor : contacts_ImportedContacts
    {
        public List<ImportedContact> imported;
        public List<long> retry_contacts;
        public List<User> users;

        public Contacts_importedContactsConstructor() { }

        public Contacts_importedContactsConstructor(List<ImportedContact> imported, List<long> retry_contacts, List<User> users)
        {
            this.imported = imported;
            this.retry_contacts = retry_contacts;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.contacts_importedContacts; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xad524315);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(imported.Count);
            foreach (ImportedContact imported_element in imported)
                imported_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(retry_contacts.Count);
            foreach (long retry_contacts_element in retry_contacts)
                writer.Write(retry_contacts_element);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int imported_count = reader.ReadInt32();
            imported = new List<ImportedContact>(imported_count);
            for (int imported_index = 0; imported_index < imported_count; imported_index++)
                imported.Add(TL.Parse<ImportedContact>(reader));
            reader.ReadUInt32(); // vector code
            int retry_contacts_count = reader.ReadInt32();
            retry_contacts = new List<long>(retry_contacts_count);
            for (int retry_contacts_index = 0; retry_contacts_index < retry_contacts_count; retry_contacts_index++)
                retry_contacts.Add(reader.ReadInt64());
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(contacts_importedContacts imported:{0} retry_contacts:{1} users:{2})", imported, retry_contacts, users);
        }
    }

    public class Contacts_blockedConstructor : contacts_Blocked
    {
        public List<ContactBlocked> blocked;
        public List<User> users;

        public Contacts_blockedConstructor() { }

        public Contacts_blockedConstructor(List<ContactBlocked> blocked, List<User> users)
        {
            this.blocked = blocked;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.contacts_blocked; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1c138d15);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(blocked.Count);
            foreach (ContactBlocked blocked_element in blocked)
                blocked_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int blocked_count = reader.ReadInt32();
            blocked = new List<ContactBlocked>(blocked_count);
            for (int blocked_index = 0; blocked_index < blocked_count; blocked_index++)
                blocked.Add(TL.Parse<ContactBlocked>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(contacts_blocked blocked:{0} users:{1})", blocked, users);
        }
    }

    public class Contacts_blockedSliceConstructor : contacts_Blocked
    {
        public int count;
        public List<ContactBlocked> blocked;
        public List<User> users;

        public Contacts_blockedSliceConstructor() { }

        public Contacts_blockedSliceConstructor(int count, List<ContactBlocked> blocked, List<User> users)
        {
            this.count = count;
            this.blocked = blocked;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.contacts_blockedSlice; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x900802a1);
            writer.Write(count);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(blocked.Count);
            foreach (ContactBlocked blocked_element in blocked)
                blocked_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            count = reader.ReadInt32();
            reader.ReadUInt32(); // vector code
            int blocked_count = reader.ReadInt32();
            blocked = new List<ContactBlocked>(blocked_count);
            for (int blocked_index = 0; blocked_index < blocked_count; blocked_index++)
                blocked.Add(TL.Parse<ContactBlocked>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(contacts_blockedSlice count:{0} blocked:{1} users:{2})", count, blocked, users);
        }
    }

    public class Contacts_suggestedConstructor : contacts_Suggested
    {
        public List<ContactSuggested> results;
        public List<User> users;

        public Contacts_suggestedConstructor() { }

        public Contacts_suggestedConstructor(List<ContactSuggested> results, List<User> users)
        {
            this.results = results;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.contacts_suggested; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5649dcc5);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(results.Count);
            foreach (ContactSuggested results_element in results)
                results_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int results_count = reader.ReadInt32();
            results = new List<ContactSuggested>(results_count);
            for (int results_index = 0; results_index < results_count; results_index++)
                results.Add(TL.Parse<ContactSuggested>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(contacts_suggested results:{0} users:{1})", results, users);
        }
    }

    public class Messages_dialogsConstructor : messages_Dialogs
    {
        public List<Dialog> dialogs;
        public List<Message> messages;
        public List<Chat> chats;
        public List<User> users;

        public Messages_dialogsConstructor() { }

        public Messages_dialogsConstructor(List<Dialog> dialogs, List<Message> messages, List<Chat> chats, List<User> users)
        {
            this.dialogs = dialogs;
            this.messages = messages;
            this.chats = chats;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.messages_dialogs; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x15ba6c40);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(dialogs.Count);
            foreach (Dialog dialogs_element in dialogs)
                dialogs_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(messages.Count);
            foreach (Message messages_element in messages)
                messages_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(chats.Count);
            foreach (Chat chats_element in chats)
                chats_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int dialogs_count = reader.ReadInt32();
            dialogs = new List<Dialog>(dialogs_count);
            for (int dialogs_index = 0; dialogs_index < dialogs_count; dialogs_index++)
                dialogs.Add(TL.Parse<Dialog>(reader));
            reader.ReadUInt32(); // vector code
            int messages_count = reader.ReadInt32();
            messages = new List<Message>(messages_count);
            for (int messages_index = 0; messages_index < messages_count; messages_index++)
                messages.Add(TL.Parse<Message>(reader));
            reader.ReadUInt32(); // vector code
            int chats_count = reader.ReadInt32();
            chats = new List<Chat>(chats_count);
            for (int chats_index = 0; chats_index < chats_count; chats_index++)
                chats.Add(TL.Parse<Chat>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(messages_dialogs dialogs:{0} messages:{1} chats:{2} users:{3})", dialogs, messages, chats, users);
        }
    }

    public class Messages_dialogsSliceConstructor : messages_Dialogs
    {
        public int count;
        public List<Dialog> dialogs;
        public List<Message> messages;
        public List<Chat> chats;
        public List<User> users;

        public Messages_dialogsSliceConstructor() { }

        public Messages_dialogsSliceConstructor(int count, List<Dialog> dialogs, List<Message> messages, List<Chat> chats, List<User> users)
        {
            this.count = count;
            this.dialogs = dialogs;
            this.messages = messages;
            this.chats = chats;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.messages_dialogsSlice; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x71e094f3);
            writer.Write(count);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(dialogs.Count);
            foreach (Dialog dialogs_element in dialogs)
                dialogs_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(messages.Count);
            foreach (Message messages_element in messages)
                messages_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(chats.Count);
            foreach (Chat chats_element in chats)
                chats_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            count = reader.ReadInt32();
            reader.ReadUInt32(); // vector code
            int dialogs_count = reader.ReadInt32();
            dialogs = new List<Dialog>(dialogs_count);
            for (int dialogs_index = 0; dialogs_index < dialogs_count; dialogs_index++)
                dialogs.Add(TL.Parse<Dialog>(reader));
            reader.ReadUInt32(); // vector code
            int messages_count = reader.ReadInt32();
            messages = new List<Message>(messages_count);
            for (int messages_index = 0; messages_index < messages_count; messages_index++)
                messages.Add(TL.Parse<Message>(reader));
            reader.ReadUInt32(); // vector code
            int chats_count = reader.ReadInt32();
            chats = new List<Chat>(chats_count);
            for (int chats_index = 0; chats_index < chats_count; chats_index++)
                chats.Add(TL.Parse<Chat>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(messages_dialogsSlice count:{0} dialogs:{1} messages:{2} chats:{3} users:{4})", count, dialogs, messages, chats, users);
        }
    }

    public class Messages_messagesConstructor : messages_Messages
    {
        public List<Message> messages;
        public List<Chat> chats;
        public List<User> users;

        public Messages_messagesConstructor() { }

        public Messages_messagesConstructor(List<Message> messages, List<Chat> chats, List<User> users)
        {
            this.messages = messages;
            this.chats = chats;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.messages_messages; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x8c718e87);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(messages.Count);
            foreach (Message messages_element in messages)
                messages_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(chats.Count);
            foreach (Chat chats_element in chats)
                chats_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int messages_count = reader.ReadInt32();
            messages = new List<Message>(messages_count);
            for (int messages_index = 0; messages_index < messages_count; messages_index++)
                messages.Add(TL.Parse<Message>(reader));
            reader.ReadUInt32(); // vector code
            int chats_count = reader.ReadInt32();
            chats = new List<Chat>(chats_count);
            for (int chats_index = 0; chats_index < chats_count; chats_index++)
                chats.Add(TL.Parse<Chat>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(messages_messages messages:{0} chats:{1} users:{2})", messages, chats, users);
        }
    }

    public class Messages_messagesSliceConstructor : messages_Messages
    {
        public int count;
        public List<Message> messages;
        public List<Chat> chats;
        public List<User> users;

        public Messages_messagesSliceConstructor() { }

        public Messages_messagesSliceConstructor(int count, List<Message> messages, List<Chat> chats, List<User> users)
        {
            this.count = count;
            this.messages = messages;
            this.chats = chats;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.messages_messagesSlice; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb446ae3);
            writer.Write(count);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(messages.Count);
            foreach (Message messages_element in messages)
                messages_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(chats.Count);
            foreach (Chat chats_element in chats)
                chats_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            count = reader.ReadInt32();
            reader.ReadUInt32(); // vector code
            int messages_count = reader.ReadInt32();
            messages = new List<Message>(messages_count);
            for (int messages_index = 0; messages_index < messages_count; messages_index++)
                messages.Add(TL.Parse<Message>(reader));
            reader.ReadUInt32(); // vector code
            int chats_count = reader.ReadInt32();
            chats = new List<Chat>(chats_count);
            for (int chats_index = 0; chats_index < chats_count; chats_index++)
                chats.Add(TL.Parse<Chat>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(messages_messagesSlice count:{0} messages:{1} chats:{2} users:{3})", count, messages, chats, users);
        }
    }

    public class Messages_channelMessagesConstructor : messages_Messages
    {
        public int flags;
        public int pts;
        public int count;
        public List<Message> messages;
        public List<MessageGroup> collapsed;
        public List<Chat> chats;
        public List<User> users;

        public Messages_channelMessagesConstructor() { }

        public Messages_channelMessagesConstructor(int flags, int pts, int count, List<Message> messages, List<MessageGroup> collapsed, List<Chat> chats, List<User> users)
        {
            this.flags = flags;
            this.pts = pts;
            this.count = count;
            this.messages = messages;
            this.collapsed = collapsed;
            this.chats = chats;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.messages_channelMessages; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xbc0f17bc);
            // Calculate flags value
            flags = 0;
            if (collapsed != null) flags += 1;

            writer.Write(flags);
            writer.Write(pts);
            writer.Write(count);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(messages.Count);
            foreach (Message messages_element in messages)
                messages_element.Write(writer);
            if (collapsed != null)
            {
                writer.Write(0x1cb5c415); // vector code
                writer.Write(collapsed.Count);
                foreach (MessageGroup collapsed_element in collapsed)
                    collapsed_element.Write(writer);
            }
            writer.Write(0x1cb5c415); // vector code
            writer.Write(chats.Count);
            foreach (Chat chats_element in chats)
                chats_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            pts = reader.ReadInt32();
            count = reader.ReadInt32();
            reader.ReadUInt32(); // vector code
            int messages_count = reader.ReadInt32();
            messages = new List<Message>(messages_count);
            for (int messages_index = 0; messages_index < messages_count; messages_index++)
                messages.Add(TL.Parse<Message>(reader));
            if ((flags & 1) != 0)
            {
                reader.ReadUInt32(); // vector code
                int collapsed_count = reader.ReadInt32();
                collapsed = new List<MessageGroup>(collapsed_count);
                for (int collapsed_index = 0; collapsed_index < collapsed_count; collapsed_index++)
                    collapsed.Add(TL.Parse<MessageGroup>(reader));
            }
            reader.ReadUInt32(); // vector code
            int chats_count = reader.ReadInt32();
            chats = new List<Chat>(chats_count);
            for (int chats_index = 0; chats_index < chats_count; chats_index++)
                chats.Add(TL.Parse<Chat>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(messages_channelMessages flags:{0} pts:{1} count:{2} messages:{3} collapsed:{4} chats:{5} users:{6})", flags, pts, count, messages, collapsed, chats, users);
        }
    }

    public class Messages_chatsConstructor : messages_Chats
    {
        public List<Chat> chats;

        public Messages_chatsConstructor() { }

        public Messages_chatsConstructor(List<Chat> chats)
        {
            this.chats = chats;
        }

        public override Constructor Constructor
        { get { return Constructor.messages_chats; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x64ff9fd5);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(chats.Count);
            foreach (Chat chats_element in chats)
                chats_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int chats_count = reader.ReadInt32();
            chats = new List<Chat>(chats_count);
            for (int chats_index = 0; chats_index < chats_count; chats_index++)
                chats.Add(TL.Parse<Chat>(reader));
        }

        public override string ToString()
        {
            return string.Format("(messages_chats chats:{0})", chats);
        }
    }

    public class Messages_chatFullConstructor : messages_ChatFull
    {
        public ChatFull full_chat;
        public List<Chat> chats;
        public List<User> users;

        public Messages_chatFullConstructor() { }

        public Messages_chatFullConstructor(ChatFull full_chat, List<Chat> chats, List<User> users)
        {
            this.full_chat = full_chat;
            this.chats = chats;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.messages_chatFull; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe5d7d19c);
            full_chat.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(chats.Count);
            foreach (Chat chats_element in chats)
                chats_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            full_chat = TL.Parse<ChatFull>(reader);
            reader.ReadUInt32(); // vector code
            int chats_count = reader.ReadInt32();
            chats = new List<Chat>(chats_count);
            for (int chats_index = 0; chats_index < chats_count; chats_index++)
                chats.Add(TL.Parse<Chat>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(messages_chatFull full_chat:{0} chats:{1} users:{2})", full_chat, chats, users);
        }
    }

    public class Messages_affectedHistoryConstructor : messages_AffectedHistory
    {
        public int pts;
        public int pts_count;
        public int offset;

        public Messages_affectedHistoryConstructor() { }

        public Messages_affectedHistoryConstructor(int pts, int pts_count, int offset)
        {
            this.pts = pts;
            this.pts_count = pts_count;
            this.offset = offset;
        }

        public override Constructor Constructor
        { get { return Constructor.messages_affectedHistory; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb45c69d1);
            writer.Write(pts);
            writer.Write(pts_count);
            writer.Write(offset);
        }

        public override void Read(BinaryReader reader)
        {
            pts = reader.ReadInt32();
            pts_count = reader.ReadInt32();
            offset = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messages_affectedHistory pts:{0} pts_count:{1} offset:{2})", pts, pts_count, offset);
        }
    }

    public class InputMessagesFilterEmptyConstructor : MessagesFilter
    {
        public InputMessagesFilterEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputMessagesFilterEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x57e2f66c);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputMessagesFilterEmpty)");
        }
    }

    public class InputMessagesFilterPhotosConstructor : MessagesFilter
    {
        public InputMessagesFilterPhotosConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputMessagesFilterPhotos; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9609a51c);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputMessagesFilterPhotos)");
        }
    }

    public class InputMessagesFilterVideoConstructor : MessagesFilter
    {
        public InputMessagesFilterVideoConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputMessagesFilterVideo; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9fc00e65);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputMessagesFilterVideo)");
        }
    }

    public class InputMessagesFilterPhotoVideoConstructor : MessagesFilter
    {
        public InputMessagesFilterPhotoVideoConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputMessagesFilterPhotoVideo; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x56e9f0e4);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputMessagesFilterPhotoVideo)");
        }
    }

    public class InputMessagesFilterPhotoVideoDocumentsConstructor : MessagesFilter
    {
        public InputMessagesFilterPhotoVideoDocumentsConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputMessagesFilterPhotoVideoDocuments; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd95e73bb);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputMessagesFilterPhotoVideoDocuments)");
        }
    }

    public class InputMessagesFilterDocumentConstructor : MessagesFilter
    {
        public InputMessagesFilterDocumentConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputMessagesFilterDocument; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9eddf188);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputMessagesFilterDocument)");
        }
    }

    public class InputMessagesFilterAudioConstructor : MessagesFilter
    {
        public InputMessagesFilterAudioConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputMessagesFilterAudio; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xcfc87522);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputMessagesFilterAudio)");
        }
    }

    public class InputMessagesFilterAudioDocumentsConstructor : MessagesFilter
    {
        public InputMessagesFilterAudioDocumentsConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputMessagesFilterAudioDocuments; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5afbf764);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputMessagesFilterAudioDocuments)");
        }
    }

    public class InputMessagesFilterUrlConstructor : MessagesFilter
    {
        public InputMessagesFilterUrlConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputMessagesFilterUrl; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7ef0dd87);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputMessagesFilterUrl)");
        }
    }

    public class UpdateNewMessageConstructor : Update
    {
        public Message message;
        public int pts;
        public int pts_count;

        public UpdateNewMessageConstructor() { }

        public UpdateNewMessageConstructor(Message message, int pts, int pts_count)
        {
            this.message = message;
            this.pts = pts;
            this.pts_count = pts_count;
        }

        public override Constructor Constructor
        { get { return Constructor.updateNewMessage; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1f2b0afd);
            message.Write(writer);
            writer.Write(pts);
            writer.Write(pts_count);
        }

        public override void Read(BinaryReader reader)
        {
            message = TL.Parse<Message>(reader);
            pts = reader.ReadInt32();
            pts_count = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateNewMessage message:{0} pts:{1} pts_count:{2})", message, pts, pts_count);
        }
    }

    public class UpdateMessageIDConstructor : Update
    {
        public int id;
        public long random_id;

        public UpdateMessageIDConstructor() { }

        public UpdateMessageIDConstructor(int id, long random_id)
        {
            this.id = id;
            this.random_id = random_id;
        }

        public override Constructor Constructor
        { get { return Constructor.updateMessageID; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4e90bfd6);
            writer.Write(id);
            writer.Write(random_id);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt32();
            random_id = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(updateMessageID id:{0} random_id:{1})", id, random_id);
        }
    }

    public class UpdateDeleteMessagesConstructor : Update
    {
        public List<int> messages;
        public int pts;
        public int pts_count;

        public UpdateDeleteMessagesConstructor() { }

        public UpdateDeleteMessagesConstructor(List<int> messages, int pts, int pts_count)
        {
            this.messages = messages;
            this.pts = pts;
            this.pts_count = pts_count;
        }

        public override Constructor Constructor
        { get { return Constructor.updateDeleteMessages; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa20db0e5);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(messages.Count);
            foreach (int messages_element in messages)
                writer.Write(messages_element);
            writer.Write(pts);
            writer.Write(pts_count);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int messages_count = reader.ReadInt32();
            messages = new List<int>(messages_count);
            for (int messages_index = 0; messages_index < messages_count; messages_index++)
                messages.Add(reader.ReadInt32());
            pts = reader.ReadInt32();
            pts_count = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateDeleteMessages messages:{0} pts:{1} pts_count:{2})", messages, pts, pts_count);
        }
    }

    public class UpdateUserTypingConstructor : Update
    {
        public int user_id;
        public SendMessageAction action;

        public UpdateUserTypingConstructor() { }

        public UpdateUserTypingConstructor(int user_id, SendMessageAction action)
        {
            this.user_id = user_id;
            this.action = action;
        }

        public override Constructor Constructor
        { get { return Constructor.updateUserTyping; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5c486927);
            writer.Write(user_id);
            action.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            action = TL.Parse<SendMessageAction>(reader);
        }

        public override string ToString()
        {
            return string.Format("(updateUserTyping user_id:{0} action:{1})", user_id, action);
        }
    }

    public class UpdateChatUserTypingConstructor : Update
    {
        public int chat_id;
        public int user_id;
        public SendMessageAction action;

        public UpdateChatUserTypingConstructor() { }

        public UpdateChatUserTypingConstructor(int chat_id, int user_id, SendMessageAction action)
        {
            this.chat_id = chat_id;
            this.user_id = user_id;
            this.action = action;
        }

        public override Constructor Constructor
        { get { return Constructor.updateChatUserTyping; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9a65ea1f);
            writer.Write(chat_id);
            writer.Write(user_id);
            action.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            chat_id = reader.ReadInt32();
            user_id = reader.ReadInt32();
            action = TL.Parse<SendMessageAction>(reader);
        }

        public override string ToString()
        {
            return string.Format("(updateChatUserTyping chat_id:{0} user_id:{1} action:{2})", chat_id, user_id, action);
        }
    }

    public class UpdateChatParticipantsConstructor : Update
    {
        public ChatParticipants participants;

        public UpdateChatParticipantsConstructor() { }

        public UpdateChatParticipantsConstructor(ChatParticipants participants)
        {
            this.participants = participants;
        }

        public override Constructor Constructor
        { get { return Constructor.updateChatParticipants; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7761198);
            participants.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            participants = TL.Parse<ChatParticipants>(reader);
        }

        public override string ToString()
        {
            return string.Format("(updateChatParticipants participants:{0})", participants);
        }
    }

    public class UpdateUserStatusConstructor : Update
    {
        public int user_id;
        public UserStatus status;

        public UpdateUserStatusConstructor() { }

        public UpdateUserStatusConstructor(int user_id, UserStatus status)
        {
            this.user_id = user_id;
            this.status = status;
        }

        public override Constructor Constructor
        { get { return Constructor.updateUserStatus; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1bfbd823);
            writer.Write(user_id);
            status.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            status = TL.Parse<UserStatus>(reader);
        }

        public override string ToString()
        {
            return string.Format("(updateUserStatus user_id:{0} status:{1})", user_id, status);
        }
    }

    public class UpdateUserNameConstructor : Update
    {
        public int user_id;
        public string first_name;
        public string last_name;
        public string username;

        public UpdateUserNameConstructor() { }

        public UpdateUserNameConstructor(int user_id, string first_name, string last_name, string username)
        {
            this.user_id = user_id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.username = username;
        }

        public override Constructor Constructor
        { get { return Constructor.updateUserName; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa7332b73);
            writer.Write(user_id);
            Serializers.String.Write(writer, first_name);
            Serializers.String.Write(writer, last_name);
            Serializers.String.Write(writer, username);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            first_name = Serializers.String.Read(reader);
            last_name = Serializers.String.Read(reader);
            username = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(updateUserName user_id:{0} first_name:{1} last_name:{2} username:{3})", user_id, first_name, last_name, username);
        }
    }

    public class UpdateUserPhotoConstructor : Update
    {
        public int user_id;
        public int date;
        public UserProfilePhoto photo;
        public bool previous;

        public UpdateUserPhotoConstructor() { }

        public UpdateUserPhotoConstructor(int user_id, int date, UserProfilePhoto photo, bool previous)
        {
            this.user_id = user_id;
            this.date = date;
            this.photo = photo;
            this.previous = previous;
        }

        public override Constructor Constructor
        { get { return Constructor.updateUserPhoto; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x95313b0c);
            writer.Write(user_id);
            writer.Write(date);
            photo.Write(writer);
            writer.Write(previous ? 0x997275b5 : 0xbc799737);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            date = reader.ReadInt32();
            photo = TL.Parse<UserProfilePhoto>(reader);
            previous = reader.ReadUInt32() == 0x997275b5;
        }

        public override string ToString()
        {
            return string.Format("(updateUserPhoto user_id:{0} date:{1} photo:{2} previous:{3})", user_id, date, photo, previous);
        }
    }

    public class UpdateContactRegisteredConstructor : Update
    {
        public int user_id;
        public int date;

        public UpdateContactRegisteredConstructor() { }

        public UpdateContactRegisteredConstructor(int user_id, int date)
        {
            this.user_id = user_id;
            this.date = date;
        }

        public override Constructor Constructor
        { get { return Constructor.updateContactRegistered; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2575bbb9);
            writer.Write(user_id);
            writer.Write(date);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateContactRegistered user_id:{0} date:{1})", user_id, date);
        }
    }

    public class UpdateContactLinkConstructor : Update
    {
        public int user_id;
        public ContactLink my_link;
        public ContactLink foreign_link;

        public UpdateContactLinkConstructor() { }

        public UpdateContactLinkConstructor(int user_id, ContactLink my_link, ContactLink foreign_link)
        {
            this.user_id = user_id;
            this.my_link = my_link;
            this.foreign_link = foreign_link;
        }

        public override Constructor Constructor
        { get { return Constructor.updateContactLink; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9d2e67c5);
            writer.Write(user_id);
            my_link.Write(writer);
            foreign_link.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            my_link = TL.Parse<ContactLink>(reader);
            foreign_link = TL.Parse<ContactLink>(reader);
        }

        public override string ToString()
        {
            return string.Format("(updateContactLink user_id:{0} my_link:{1} foreign_link:{2})", user_id, my_link, foreign_link);
        }
    }

    public class UpdateNewAuthorizationConstructor : Update
    {
        public long auth_key_id;
        public int date;
        public string device;
        public string location;

        public UpdateNewAuthorizationConstructor() { }

        public UpdateNewAuthorizationConstructor(long auth_key_id, int date, string device, string location)
        {
            this.auth_key_id = auth_key_id;
            this.date = date;
            this.device = device;
            this.location = location;
        }

        public override Constructor Constructor
        { get { return Constructor.updateNewAuthorization; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x8f06529a);
            writer.Write(auth_key_id);
            writer.Write(date);
            Serializers.String.Write(writer, device);
            Serializers.String.Write(writer, location);
        }

        public override void Read(BinaryReader reader)
        {
            auth_key_id = reader.ReadInt64();
            date = reader.ReadInt32();
            device = Serializers.String.Read(reader);
            location = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(updateNewAuthorization auth_key_id:{0} date:{1} device:{2} location:{3})", auth_key_id, date, device, location);
        }
    }

    public class UpdateNewEncryptedMessageConstructor : Update
    {
        public EncryptedMessage message;
        public int qts;

        public UpdateNewEncryptedMessageConstructor() { }

        public UpdateNewEncryptedMessageConstructor(EncryptedMessage message, int qts)
        {
            this.message = message;
            this.qts = qts;
        }

        public override Constructor Constructor
        { get { return Constructor.updateNewEncryptedMessage; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x12bcbd9a);
            message.Write(writer);
            writer.Write(qts);
        }

        public override void Read(BinaryReader reader)
        {
            message = TL.Parse<EncryptedMessage>(reader);
            qts = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateNewEncryptedMessage message:{0} qts:{1})", message, qts);
        }
    }

    public class UpdateEncryptedChatTypingConstructor : Update
    {
        public int chat_id;

        public UpdateEncryptedChatTypingConstructor() { }

        public UpdateEncryptedChatTypingConstructor(int chat_id)
        {
            this.chat_id = chat_id;
        }

        public override Constructor Constructor
        { get { return Constructor.updateEncryptedChatTyping; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1710f156);
            writer.Write(chat_id);
        }

        public override void Read(BinaryReader reader)
        {
            chat_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateEncryptedChatTyping chat_id:{0})", chat_id);
        }
    }

    public class UpdateEncryptionConstructor : Update
    {
        public EncryptedChat chat;
        public int date;

        public UpdateEncryptionConstructor() { }

        public UpdateEncryptionConstructor(EncryptedChat chat, int date)
        {
            this.chat = chat;
            this.date = date;
        }

        public override Constructor Constructor
        { get { return Constructor.updateEncryption; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb4a2e88d);
            chat.Write(writer);
            writer.Write(date);
        }

        public override void Read(BinaryReader reader)
        {
            chat = TL.Parse<EncryptedChat>(reader);
            date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateEncryption chat:{0} date:{1})", chat, date);
        }
    }

    public class UpdateEncryptedMessagesReadConstructor : Update
    {
        public int chat_id;
        public int max_date;
        public int date;

        public UpdateEncryptedMessagesReadConstructor() { }

        public UpdateEncryptedMessagesReadConstructor(int chat_id, int max_date, int date)
        {
            this.chat_id = chat_id;
            this.max_date = max_date;
            this.date = date;
        }

        public override Constructor Constructor
        { get { return Constructor.updateEncryptedMessagesRead; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x38fe25b7);
            writer.Write(chat_id);
            writer.Write(max_date);
            writer.Write(date);
        }

        public override void Read(BinaryReader reader)
        {
            chat_id = reader.ReadInt32();
            max_date = reader.ReadInt32();
            date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateEncryptedMessagesRead chat_id:{0} max_date:{1} date:{2})", chat_id, max_date, date);
        }
    }

    public class UpdateChatParticipantAddConstructor : Update
    {
        public int chat_id;
        public int user_id;
        public int inviter_id;
        public int date;
        public int version;

        public UpdateChatParticipantAddConstructor() { }

        public UpdateChatParticipantAddConstructor(int chat_id, int user_id, int inviter_id, int date, int version)
        {
            this.chat_id = chat_id;
            this.user_id = user_id;
            this.inviter_id = inviter_id;
            this.date = date;
            this.version = version;
        }

        public override Constructor Constructor
        { get { return Constructor.updateChatParticipantAdd; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xea4b0e5c);
            writer.Write(chat_id);
            writer.Write(user_id);
            writer.Write(inviter_id);
            writer.Write(date);
            writer.Write(version);
        }

        public override void Read(BinaryReader reader)
        {
            chat_id = reader.ReadInt32();
            user_id = reader.ReadInt32();
            inviter_id = reader.ReadInt32();
            date = reader.ReadInt32();
            version = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateChatParticipantAdd chat_id:{0} user_id:{1} inviter_id:{2} date:{3} version:{4})", chat_id, user_id, inviter_id, date, version);
        }
    }

    public class UpdateChatParticipantDeleteConstructor : Update
    {
        public int chat_id;
        public int user_id;
        public int version;

        public UpdateChatParticipantDeleteConstructor() { }

        public UpdateChatParticipantDeleteConstructor(int chat_id, int user_id, int version)
        {
            this.chat_id = chat_id;
            this.user_id = user_id;
            this.version = version;
        }

        public override Constructor Constructor
        { get { return Constructor.updateChatParticipantDelete; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6e5f8c22);
            writer.Write(chat_id);
            writer.Write(user_id);
            writer.Write(version);
        }

        public override void Read(BinaryReader reader)
        {
            chat_id = reader.ReadInt32();
            user_id = reader.ReadInt32();
            version = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateChatParticipantDelete chat_id:{0} user_id:{1} version:{2})", chat_id, user_id, version);
        }
    }

    public class UpdateDcOptionsConstructor : Update
    {
        public List<DcOption> dc_options;

        public UpdateDcOptionsConstructor() { }

        public UpdateDcOptionsConstructor(List<DcOption> dc_options)
        {
            this.dc_options = dc_options;
        }

        public override Constructor Constructor
        { get { return Constructor.updateDcOptions; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x8e5e9873);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(dc_options.Count);
            foreach (DcOption dc_options_element in dc_options)
                dc_options_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int dc_options_count = reader.ReadInt32();
            dc_options = new List<DcOption>(dc_options_count);
            for (int dc_options_index = 0; dc_options_index < dc_options_count; dc_options_index++)
                dc_options.Add(TL.Parse<DcOption>(reader));
        }

        public override string ToString()
        {
            return string.Format("(updateDcOptions dc_options:{0})", dc_options);
        }
    }

    public class UpdateUserBlockedConstructor : Update
    {
        public int user_id;
        public bool blocked;

        public UpdateUserBlockedConstructor() { }

        public UpdateUserBlockedConstructor(int user_id, bool blocked)
        {
            this.user_id = user_id;
            this.blocked = blocked;
        }

        public override Constructor Constructor
        { get { return Constructor.updateUserBlocked; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x80ece81a);
            writer.Write(user_id);
            writer.Write(blocked ? 0x997275b5 : 0xbc799737);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            blocked = reader.ReadUInt32() == 0x997275b5;
        }

        public override string ToString()
        {
            return string.Format("(updateUserBlocked user_id:{0} blocked:{1})", user_id, blocked);
        }
    }

    public class UpdateNotifySettingsConstructor : Update
    {
        public NotifyPeer peer;
        public PeerNotifySettings notify_settings;

        public UpdateNotifySettingsConstructor() { }

        public UpdateNotifySettingsConstructor(NotifyPeer peer, PeerNotifySettings notify_settings)
        {
            this.peer = peer;
            this.notify_settings = notify_settings;
        }

        public override Constructor Constructor
        { get { return Constructor.updateNotifySettings; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xbec268ef);
            peer.Write(writer);
            notify_settings.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            peer = TL.Parse<NotifyPeer>(reader);
            notify_settings = TL.Parse<PeerNotifySettings>(reader);
        }

        public override string ToString()
        {
            return string.Format("(updateNotifySettings peer:{0} notify_settings:{1})", peer, notify_settings);
        }
    }

    public class UpdateServiceNotificationConstructor : Update
    {
        public string type;
        public string message;
        public MessageMedia media;
        public bool popup;

        public UpdateServiceNotificationConstructor() { }

        public UpdateServiceNotificationConstructor(string type, string message, MessageMedia media, bool popup)
        {
            this.type = type;
            this.message = message;
            this.media = media;
            this.popup = popup;
        }

        public override Constructor Constructor
        { get { return Constructor.updateServiceNotification; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x382dd3e4);
            Serializers.String.Write(writer, type);
            Serializers.String.Write(writer, message);
            media.Write(writer);
            writer.Write(popup ? 0x997275b5 : 0xbc799737);
        }

        public override void Read(BinaryReader reader)
        {
            type = Serializers.String.Read(reader);
            message = Serializers.String.Read(reader);
            media = TL.Parse<MessageMedia>(reader);
            popup = reader.ReadUInt32() == 0x997275b5;
        }

        public override string ToString()
        {
            return string.Format("(updateServiceNotification type:{0} message:{1} media:{2} popup:{3})", type, message, media, popup);
        }
    }

    public class UpdatePrivacyConstructor : Update
    {
        public PrivacyKey key;
        public List<PrivacyRule> rules;

        public UpdatePrivacyConstructor() { }

        public UpdatePrivacyConstructor(PrivacyKey key, List<PrivacyRule> rules)
        {
            this.key = key;
            this.rules = rules;
        }

        public override Constructor Constructor
        { get { return Constructor.updatePrivacy; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xee3b272a);
            key.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(rules.Count);
            foreach (PrivacyRule rules_element in rules)
                rules_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            key = TL.Parse<PrivacyKey>(reader);
            reader.ReadUInt32(); // vector code
            int rules_count = reader.ReadInt32();
            rules = new List<PrivacyRule>(rules_count);
            for (int rules_index = 0; rules_index < rules_count; rules_index++)
                rules.Add(TL.Parse<PrivacyRule>(reader));
        }

        public override string ToString()
        {
            return string.Format("(updatePrivacy key:{0} rules:{1})", key, rules);
        }
    }

    public class UpdateUserPhoneConstructor : Update
    {
        public int user_id;
        public string phone;

        public UpdateUserPhoneConstructor() { }

        public UpdateUserPhoneConstructor(int user_id, string phone)
        {
            this.user_id = user_id;
            this.phone = phone;
        }

        public override Constructor Constructor
        { get { return Constructor.updateUserPhone; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x12b9417b);
            writer.Write(user_id);
            Serializers.String.Write(writer, phone);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            phone = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(updateUserPhone user_id:{0} phone:{1})", user_id, phone);
        }
    }

    public class UpdateReadHistoryInboxConstructor : Update
    {
        public Peer peer;
        public int max_id;
        public int pts;
        public int pts_count;

        public UpdateReadHistoryInboxConstructor() { }

        public UpdateReadHistoryInboxConstructor(Peer peer, int max_id, int pts, int pts_count)
        {
            this.peer = peer;
            this.max_id = max_id;
            this.pts = pts;
            this.pts_count = pts_count;
        }

        public override Constructor Constructor
        { get { return Constructor.updateReadHistoryInbox; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9961fd5c);
            peer.Write(writer);
            writer.Write(max_id);
            writer.Write(pts);
            writer.Write(pts_count);
        }

        public override void Read(BinaryReader reader)
        {
            peer = TL.Parse<Peer>(reader);
            max_id = reader.ReadInt32();
            pts = reader.ReadInt32();
            pts_count = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateReadHistoryInbox peer:{0} max_id:{1} pts:{2} pts_count:{3})", peer, max_id, pts, pts_count);
        }
    }

    public class UpdateReadHistoryOutboxConstructor : Update
    {
        public Peer peer;
        public int max_id;
        public int pts;
        public int pts_count;

        public UpdateReadHistoryOutboxConstructor() { }

        public UpdateReadHistoryOutboxConstructor(Peer peer, int max_id, int pts, int pts_count)
        {
            this.peer = peer;
            this.max_id = max_id;
            this.pts = pts;
            this.pts_count = pts_count;
        }

        public override Constructor Constructor
        { get { return Constructor.updateReadHistoryOutbox; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2f2f21bf);
            peer.Write(writer);
            writer.Write(max_id);
            writer.Write(pts);
            writer.Write(pts_count);
        }

        public override void Read(BinaryReader reader)
        {
            peer = TL.Parse<Peer>(reader);
            max_id = reader.ReadInt32();
            pts = reader.ReadInt32();
            pts_count = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateReadHistoryOutbox peer:{0} max_id:{1} pts:{2} pts_count:{3})", peer, max_id, pts, pts_count);
        }
    }

    public class UpdateWebPageConstructor : Update
    {
        public WebPage webpage;
        public int pts;
        public int pts_count;

        public UpdateWebPageConstructor() { }

        public UpdateWebPageConstructor(WebPage webpage, int pts, int pts_count)
        {
            this.webpage = webpage;
            this.pts = pts;
            this.pts_count = pts_count;
        }

        public override Constructor Constructor
        { get { return Constructor.updateWebPage; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7f891213);
            webpage.Write(writer);
            writer.Write(pts);
            writer.Write(pts_count);
        }

        public override void Read(BinaryReader reader)
        {
            webpage = TL.Parse<WebPage>(reader);
            pts = reader.ReadInt32();
            pts_count = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateWebPage webpage:{0} pts:{1} pts_count:{2})", webpage, pts, pts_count);
        }
    }

    public class UpdateReadMessagesContentsConstructor : Update
    {
        public List<int> messages;
        public int pts;
        public int pts_count;

        public UpdateReadMessagesContentsConstructor() { }

        public UpdateReadMessagesContentsConstructor(List<int> messages, int pts, int pts_count)
        {
            this.messages = messages;
            this.pts = pts;
            this.pts_count = pts_count;
        }

        public override Constructor Constructor
        { get { return Constructor.updateReadMessagesContents; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x68c13933);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(messages.Count);
            foreach (int messages_element in messages)
                writer.Write(messages_element);
            writer.Write(pts);
            writer.Write(pts_count);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int messages_count = reader.ReadInt32();
            messages = new List<int>(messages_count);
            for (int messages_index = 0; messages_index < messages_count; messages_index++)
                messages.Add(reader.ReadInt32());
            pts = reader.ReadInt32();
            pts_count = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateReadMessagesContents messages:{0} pts:{1} pts_count:{2})", messages, pts, pts_count);
        }
    }

    public class UpdateChannelTooLongConstructor : Update
    {
        public int channel_id;

        public UpdateChannelTooLongConstructor() { }

        public UpdateChannelTooLongConstructor(int channel_id)
        {
            this.channel_id = channel_id;
        }

        public override Constructor Constructor
        { get { return Constructor.updateChannelTooLong; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x60946422);
            writer.Write(channel_id);
        }

        public override void Read(BinaryReader reader)
        {
            channel_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateChannelTooLong channel_id:{0})", channel_id);
        }
    }

    public class UpdateChannelConstructor : Update
    {
        public int channel_id;

        public UpdateChannelConstructor() { }

        public UpdateChannelConstructor(int channel_id)
        {
            this.channel_id = channel_id;
        }

        public override Constructor Constructor
        { get { return Constructor.updateChannel; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb6d45656);
            writer.Write(channel_id);
        }

        public override void Read(BinaryReader reader)
        {
            channel_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateChannel channel_id:{0})", channel_id);
        }
    }

    public class UpdateChannelGroupConstructor : Update
    {
        public int channel_id;
        public MessageGroup group;

        public UpdateChannelGroupConstructor() { }

        public UpdateChannelGroupConstructor(int channel_id, MessageGroup group)
        {
            this.channel_id = channel_id;
            this.group = group;
        }

        public override Constructor Constructor
        { get { return Constructor.updateChannelGroup; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc36c1e3c);
            writer.Write(channel_id);
            group.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            channel_id = reader.ReadInt32();
            group = TL.Parse<MessageGroup>(reader);
        }

        public override string ToString()
        {
            return string.Format("(updateChannelGroup channel_id:{0} group:{1})", channel_id, group);
        }
    }

    public class UpdateNewChannelMessageConstructor : Update
    {
        public Message message;
        public int pts;
        public int pts_count;

        public UpdateNewChannelMessageConstructor() { }

        public UpdateNewChannelMessageConstructor(Message message, int pts, int pts_count)
        {
            this.message = message;
            this.pts = pts;
            this.pts_count = pts_count;
        }

        public override Constructor Constructor
        { get { return Constructor.updateNewChannelMessage; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x62ba04d9);
            message.Write(writer);
            writer.Write(pts);
            writer.Write(pts_count);
        }

        public override void Read(BinaryReader reader)
        {
            message = TL.Parse<Message>(reader);
            pts = reader.ReadInt32();
            pts_count = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateNewChannelMessage message:{0} pts:{1} pts_count:{2})", message, pts, pts_count);
        }
    }

    public class UpdateReadChannelInboxConstructor : Update
    {
        public int channel_id;
        public int max_id;

        public UpdateReadChannelInboxConstructor() { }

        public UpdateReadChannelInboxConstructor(int channel_id, int max_id)
        {
            this.channel_id = channel_id;
            this.max_id = max_id;
        }

        public override Constructor Constructor
        { get { return Constructor.updateReadChannelInbox; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4214f37f);
            writer.Write(channel_id);
            writer.Write(max_id);
        }

        public override void Read(BinaryReader reader)
        {
            channel_id = reader.ReadInt32();
            max_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateReadChannelInbox channel_id:{0} max_id:{1})", channel_id, max_id);
        }
    }

    public class UpdateDeleteChannelMessagesConstructor : Update
    {
        public int channel_id;
        public List<int> messages;
        public int pts;
        public int pts_count;

        public UpdateDeleteChannelMessagesConstructor() { }

        public UpdateDeleteChannelMessagesConstructor(int channel_id, List<int> messages, int pts, int pts_count)
        {
            this.channel_id = channel_id;
            this.messages = messages;
            this.pts = pts;
            this.pts_count = pts_count;
        }

        public override Constructor Constructor
        { get { return Constructor.updateDeleteChannelMessages; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc37521c9);
            writer.Write(channel_id);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(messages.Count);
            foreach (int messages_element in messages)
                writer.Write(messages_element);
            writer.Write(pts);
            writer.Write(pts_count);
        }

        public override void Read(BinaryReader reader)
        {
            channel_id = reader.ReadInt32();
            reader.ReadUInt32(); // vector code
            int messages_count = reader.ReadInt32();
            messages = new List<int>(messages_count);
            for (int messages_index = 0; messages_index < messages_count; messages_index++)
                messages.Add(reader.ReadInt32());
            pts = reader.ReadInt32();
            pts_count = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateDeleteChannelMessages channel_id:{0} messages:{1} pts:{2} pts_count:{3})", channel_id, messages, pts, pts_count);
        }
    }

    public class UpdateChannelMessageViewsConstructor : Update
    {
        public int channel_id;
        public int id;
        public int views;

        public UpdateChannelMessageViewsConstructor() { }

        public UpdateChannelMessageViewsConstructor(int channel_id, int id, int views)
        {
            this.channel_id = channel_id;
            this.id = id;
            this.views = views;
        }

        public override Constructor Constructor
        { get { return Constructor.updateChannelMessageViews; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x98a12b4b);
            writer.Write(channel_id);
            writer.Write(id);
            writer.Write(views);
        }

        public override void Read(BinaryReader reader)
        {
            channel_id = reader.ReadInt32();
            id = reader.ReadInt32();
            views = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateChannelMessageViews channel_id:{0} id:{1} views:{2})", channel_id, id, views);
        }
    }

    public class Updates_stateConstructor : updates_State
    {
        public int pts;
        public int qts;
        public int date;
        public int seq;
        public int unread_count;

        public Updates_stateConstructor() { }

        public Updates_stateConstructor(int pts, int qts, int date, int seq, int unread_count)
        {
            this.pts = pts;
            this.qts = qts;
            this.date = date;
            this.seq = seq;
            this.unread_count = unread_count;
        }

        public override Constructor Constructor
        { get { return Constructor.updates_state; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa56c2a3e);
            writer.Write(pts);
            writer.Write(qts);
            writer.Write(date);
            writer.Write(seq);
            writer.Write(unread_count);
        }

        public override void Read(BinaryReader reader)
        {
            pts = reader.ReadInt32();
            qts = reader.ReadInt32();
            date = reader.ReadInt32();
            seq = reader.ReadInt32();
            unread_count = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updates_state pts:{0} qts:{1} date:{2} seq:{3} unread_count:{4})", pts, qts, date, seq, unread_count);
        }
    }

    public class Updates_differenceEmptyConstructor : updates_Difference
    {
        public int date;
        public int seq;

        public Updates_differenceEmptyConstructor() { }

        public Updates_differenceEmptyConstructor(int date, int seq)
        {
            this.date = date;
            this.seq = seq;
        }

        public override Constructor Constructor
        { get { return Constructor.updates_differenceEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5d75a138);
            writer.Write(date);
            writer.Write(seq);
        }

        public override void Read(BinaryReader reader)
        {
            date = reader.ReadInt32();
            seq = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updates_differenceEmpty date:{0} seq:{1})", date, seq);
        }
    }

    public class Updates_differenceConstructor : updates_Difference
    {
        public List<Message> new_messages;
        public List<EncryptedMessage> new_encrypted_messages;
        public List<Update> other_updates;
        public List<Chat> chats;
        public List<User> users;
        public updates_State state;

        public Updates_differenceConstructor() { }

        public Updates_differenceConstructor(List<Message> new_messages, List<EncryptedMessage> new_encrypted_messages, List<Update> other_updates, List<Chat> chats, List<User> users, updates_State state)
        {
            this.new_messages = new_messages;
            this.new_encrypted_messages = new_encrypted_messages;
            this.other_updates = other_updates;
            this.chats = chats;
            this.users = users;
            this.state = state;
        }

        public override Constructor Constructor
        { get { return Constructor.updates_difference; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf49ca0);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(new_messages.Count);
            foreach (Message new_messages_element in new_messages)
                new_messages_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(new_encrypted_messages.Count);
            foreach (EncryptedMessage new_encrypted_messages_element in new_encrypted_messages)
                new_encrypted_messages_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(other_updates.Count);
            foreach (Update other_updates_element in other_updates)
                other_updates_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(chats.Count);
            foreach (Chat chats_element in chats)
                chats_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
            state.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int new_messages_count = reader.ReadInt32();
            new_messages = new List<Message>(new_messages_count);
            for (int new_messages_index = 0; new_messages_index < new_messages_count; new_messages_index++)
                new_messages.Add(TL.Parse<Message>(reader));
            reader.ReadUInt32(); // vector code
            int new_encrypted_messages_count = reader.ReadInt32();
            new_encrypted_messages = new List<EncryptedMessage>(new_encrypted_messages_count);
            for (int new_encrypted_messages_index = 0; new_encrypted_messages_index < new_encrypted_messages_count; new_encrypted_messages_index++)
                new_encrypted_messages.Add(TL.Parse<EncryptedMessage>(reader));
            reader.ReadUInt32(); // vector code
            int other_updates_count = reader.ReadInt32();
            other_updates = new List<Update>(other_updates_count);
            for (int other_updates_index = 0; other_updates_index < other_updates_count; other_updates_index++)
                other_updates.Add(TL.Parse<Update>(reader));
            reader.ReadUInt32(); // vector code
            int chats_count = reader.ReadInt32();
            chats = new List<Chat>(chats_count);
            for (int chats_index = 0; chats_index < chats_count; chats_index++)
                chats.Add(TL.Parse<Chat>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
            state = TL.Parse<updates_State>(reader);
        }

        public override string ToString()
        {
            return string.Format("(updates_difference new_messages:{0} new_encrypted_messages:{1} other_updates:{2} chats:{3} users:{4} state:{5})", new_messages, new_encrypted_messages, other_updates, chats, users, state);
        }
    }

    public class Updates_differenceSliceConstructor : updates_Difference
    {
        public List<Message> new_messages;
        public List<EncryptedMessage> new_encrypted_messages;
        public List<Update> other_updates;
        public List<Chat> chats;
        public List<User> users;
        public updates_State intermediate_state;

        public Updates_differenceSliceConstructor() { }

        public Updates_differenceSliceConstructor(List<Message> new_messages, List<EncryptedMessage> new_encrypted_messages, List<Update> other_updates, List<Chat> chats, List<User> users, updates_State intermediate_state)
        {
            this.new_messages = new_messages;
            this.new_encrypted_messages = new_encrypted_messages;
            this.other_updates = other_updates;
            this.chats = chats;
            this.users = users;
            this.intermediate_state = intermediate_state;
        }

        public override Constructor Constructor
        { get { return Constructor.updates_differenceSlice; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa8fb1981);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(new_messages.Count);
            foreach (Message new_messages_element in new_messages)
                new_messages_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(new_encrypted_messages.Count);
            foreach (EncryptedMessage new_encrypted_messages_element in new_encrypted_messages)
                new_encrypted_messages_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(other_updates.Count);
            foreach (Update other_updates_element in other_updates)
                other_updates_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(chats.Count);
            foreach (Chat chats_element in chats)
                chats_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
            intermediate_state.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int new_messages_count = reader.ReadInt32();
            new_messages = new List<Message>(new_messages_count);
            for (int new_messages_index = 0; new_messages_index < new_messages_count; new_messages_index++)
                new_messages.Add(TL.Parse<Message>(reader));
            reader.ReadUInt32(); // vector code
            int new_encrypted_messages_count = reader.ReadInt32();
            new_encrypted_messages = new List<EncryptedMessage>(new_encrypted_messages_count);
            for (int new_encrypted_messages_index = 0; new_encrypted_messages_index < new_encrypted_messages_count; new_encrypted_messages_index++)
                new_encrypted_messages.Add(TL.Parse<EncryptedMessage>(reader));
            reader.ReadUInt32(); // vector code
            int other_updates_count = reader.ReadInt32();
            other_updates = new List<Update>(other_updates_count);
            for (int other_updates_index = 0; other_updates_index < other_updates_count; other_updates_index++)
                other_updates.Add(TL.Parse<Update>(reader));
            reader.ReadUInt32(); // vector code
            int chats_count = reader.ReadInt32();
            chats = new List<Chat>(chats_count);
            for (int chats_index = 0; chats_index < chats_count; chats_index++)
                chats.Add(TL.Parse<Chat>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
            intermediate_state = TL.Parse<updates_State>(reader);
        }

        public override string ToString()
        {
            return string.Format("(updates_differenceSlice new_messages:{0} new_encrypted_messages:{1} other_updates:{2} chats:{3} users:{4} intermediate_state:{5})", new_messages, new_encrypted_messages, other_updates, chats, users, intermediate_state);
        }
    }

    public class UpdatesTooLongConstructor : Updates
    {
        public UpdatesTooLongConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.updatesTooLong; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe317af7e);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(updatesTooLong)");
        }
    }

    public class UpdateShortMessageConstructor : Updates
    {
        public int flags;
        public int id;
        public int user_id;
        public string message;
        public int pts;
        public int pts_count;
        public int date;
        public Peer fwd_from_id;
        public int? fwd_date;
        public int? reply_to_msg_id;
        public List<MessageEntity> entities;

        public UpdateShortMessageConstructor() { }

        public UpdateShortMessageConstructor(int flags, int id, int user_id, string message, int pts, int pts_count, int date, Peer fwd_from_id, int? fwd_date, int? reply_to_msg_id, List<MessageEntity> entities)
        {
            this.flags = flags;
            this.id = id;
            this.user_id = user_id;
            this.message = message;
            this.pts = pts;
            this.pts_count = pts_count;
            this.date = date;
            this.fwd_from_id = fwd_from_id;
            this.fwd_date = fwd_date;
            this.reply_to_msg_id = reply_to_msg_id;
            this.entities = entities;
        }

        public override Constructor Constructor
        { get { return Constructor.updateShortMessage; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf7d91a46);
            // Calculate flags value
            flags = 0;
            if (fwd_from_id != null) flags += 4;
            if (reply_to_msg_id != null) flags += 8;
            if (entities != null) flags += 128;

            writer.Write(flags);
            writer.Write(id);
            writer.Write(user_id);
            Serializers.String.Write(writer, message);
            writer.Write(pts);
            writer.Write(pts_count);
            writer.Write(date);
            if (fwd_from_id != null)
            {
                fwd_from_id.Write(writer);
            }
            if (fwd_date != null)
            {
                writer.Write(fwd_date.Value);
            }
            if (reply_to_msg_id != null)
            {
                writer.Write(reply_to_msg_id.Value);
            }
            if (entities != null)
            {
                writer.Write(0x1cb5c415); // vector code
                writer.Write(entities.Count);
                foreach (MessageEntity entities_element in entities)
                    entities_element.Write(writer);
            }
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            id = reader.ReadInt32();
            user_id = reader.ReadInt32();
            message = Serializers.String.Read(reader);
            pts = reader.ReadInt32();
            pts_count = reader.ReadInt32();
            date = reader.ReadInt32();
            if ((flags & 4) != 0)
            {
                fwd_from_id = TL.Parse<Peer>(reader);
            }
            if ((flags & 4) != 0)
            {
                fwd_date = reader.ReadInt32();
            }
            if ((flags & 8) != 0)
            {
                reply_to_msg_id = reader.ReadInt32();
            }
            if ((flags & 128) != 0)
            {
                reader.ReadUInt32(); // vector code
                int entities_count = reader.ReadInt32();
                entities = new List<MessageEntity>(entities_count);
                for (int entities_index = 0; entities_index < entities_count; entities_index++)
                    entities.Add(TL.Parse<MessageEntity>(reader));
            }
        }

        public override string ToString()
        {
            return string.Format("(updateShortMessage flags:{0} id:{1} user_id:{2} message:{3} pts:{4} pts_count:{5} date:{6} fwd_from_id:{7} fwd_date:{8} reply_to_msg_id:{9} entities:{10})", flags, id, user_id, message, pts, pts_count, date, fwd_from_id, fwd_date, reply_to_msg_id, entities);
        }
    }

    public class UpdateShortChatMessageConstructor : Updates
    {
        public int flags;
        public int id;
        public int from_id;
        public int chat_id;
        public string message;
        public int pts;
        public int pts_count;
        public int date;
        public Peer fwd_from_id;
        public int? fwd_date;
        public int? reply_to_msg_id;
        public List<MessageEntity> entities;

        public UpdateShortChatMessageConstructor() { }

        public UpdateShortChatMessageConstructor(int flags, int id, int from_id, int chat_id, string message, int pts, int pts_count, int date, Peer fwd_from_id, int? fwd_date, int? reply_to_msg_id, List<MessageEntity> entities)
        {
            this.flags = flags;
            this.id = id;
            this.from_id = from_id;
            this.chat_id = chat_id;
            this.message = message;
            this.pts = pts;
            this.pts_count = pts_count;
            this.date = date;
            this.fwd_from_id = fwd_from_id;
            this.fwd_date = fwd_date;
            this.reply_to_msg_id = reply_to_msg_id;
            this.entities = entities;
        }

        public override Constructor Constructor
        { get { return Constructor.updateShortChatMessage; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xcac7fdd2);
            // Calculate flags value
            flags = 0;
            if (fwd_from_id != null) flags += 4;
            if (reply_to_msg_id != null) flags += 8;
            if (entities != null) flags += 128;

            writer.Write(flags);
            writer.Write(id);
            writer.Write(from_id);
            writer.Write(chat_id);
            Serializers.String.Write(writer, message);
            writer.Write(pts);
            writer.Write(pts_count);
            writer.Write(date);
            if (fwd_from_id != null)
            {
                fwd_from_id.Write(writer);
            }
            if (fwd_date != null)
            {
                writer.Write(fwd_date.Value);
            }
            if (reply_to_msg_id != null)
            {
                writer.Write(reply_to_msg_id.Value);
            }
            if (entities != null)
            {
                writer.Write(0x1cb5c415); // vector code
                writer.Write(entities.Count);
                foreach (MessageEntity entities_element in entities)
                    entities_element.Write(writer);
            }
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            id = reader.ReadInt32();
            from_id = reader.ReadInt32();
            chat_id = reader.ReadInt32();
            message = Serializers.String.Read(reader);
            pts = reader.ReadInt32();
            pts_count = reader.ReadInt32();
            date = reader.ReadInt32();
            if ((flags & 4) != 0)
            {
                fwd_from_id = TL.Parse<Peer>(reader);
            }
            if ((flags & 4) != 0)
            {
                fwd_date = reader.ReadInt32();
            }
            if ((flags & 8) != 0)
            {
                reply_to_msg_id = reader.ReadInt32();
            }
            if ((flags & 128) != 0)
            {
                reader.ReadUInt32(); // vector code
                int entities_count = reader.ReadInt32();
                entities = new List<MessageEntity>(entities_count);
                for (int entities_index = 0; entities_index < entities_count; entities_index++)
                    entities.Add(TL.Parse<MessageEntity>(reader));
            }
        }

        public override string ToString()
        {
            return string.Format("(updateShortChatMessage flags:{0} id:{1} from_id:{2} chat_id:{3} message:{4} pts:{5} pts_count:{6} date:{7} fwd_from_id:{8} fwd_date:{9} reply_to_msg_id:{10} entities:{11})", flags, id, from_id, chat_id, message, pts, pts_count, date, fwd_from_id, fwd_date, reply_to_msg_id, entities);
        }
    }

    public class UpdateShortConstructor : Updates
    {
        public Update update;
        public int date;

        public UpdateShortConstructor() { }

        public UpdateShortConstructor(Update update, int date)
        {
            this.update = update;
            this.date = date;
        }

        public override Constructor Constructor
        { get { return Constructor.updateShort; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x78d4dec1);
            update.Write(writer);
            writer.Write(date);
        }

        public override void Read(BinaryReader reader)
        {
            update = TL.Parse<Update>(reader);
            date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updateShort update:{0} date:{1})", update, date);
        }
    }

    public class UpdatesCombinedConstructor : Updates
    {
        public List<Update> updates;
        public List<User> users;
        public List<Chat> chats;
        public int date;
        public int seq_start;
        public int seq;

        public UpdatesCombinedConstructor() { }

        public UpdatesCombinedConstructor(List<Update> updates, List<User> users, List<Chat> chats, int date, int seq_start, int seq)
        {
            this.updates = updates;
            this.users = users;
            this.chats = chats;
            this.date = date;
            this.seq_start = seq_start;
            this.seq = seq;
        }

        public override Constructor Constructor
        { get { return Constructor.updatesCombined; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x725b04c3);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(updates.Count);
            foreach (Update updates_element in updates)
                updates_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(chats.Count);
            foreach (Chat chats_element in chats)
                chats_element.Write(writer);
            writer.Write(date);
            writer.Write(seq_start);
            writer.Write(seq);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int updates_count = reader.ReadInt32();
            updates = new List<Update>(updates_count);
            for (int updates_index = 0; updates_index < updates_count; updates_index++)
                updates.Add(TL.Parse<Update>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
            reader.ReadUInt32(); // vector code
            int chats_count = reader.ReadInt32();
            chats = new List<Chat>(chats_count);
            for (int chats_index = 0; chats_index < chats_count; chats_index++)
                chats.Add(TL.Parse<Chat>(reader));
            date = reader.ReadInt32();
            seq_start = reader.ReadInt32();
            seq = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updatesCombined updates:{0} users:{1} chats:{2} date:{3} seq_start:{4} seq:{5})", updates, users, chats, date, seq_start, seq);
        }
    }

    public class UpdatesConstructor : Updates
    {
        public List<Update> updates;
        public List<User> users;
        public List<Chat> chats;
        public int date;
        public int seq;

        public UpdatesConstructor() { }

        public UpdatesConstructor(List<Update> updates, List<User> users, List<Chat> chats, int date, int seq)
        {
            this.updates = updates;
            this.users = users;
            this.chats = chats;
            this.date = date;
            this.seq = seq;
        }

        public override Constructor Constructor
        { get { return Constructor.updates; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x74ae4240);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(updates.Count);
            foreach (Update updates_element in updates)
                updates_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(chats.Count);
            foreach (Chat chats_element in chats)
                chats_element.Write(writer);
            writer.Write(date);
            writer.Write(seq);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int updates_count = reader.ReadInt32();
            updates = new List<Update>(updates_count);
            for (int updates_index = 0; updates_index < updates_count; updates_index++)
                updates.Add(TL.Parse<Update>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
            reader.ReadUInt32(); // vector code
            int chats_count = reader.ReadInt32();
            chats = new List<Chat>(chats_count);
            for (int chats_index = 0; chats_index < chats_count; chats_index++)
                chats.Add(TL.Parse<Chat>(reader));
            date = reader.ReadInt32();
            seq = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(updates updates:{0} users:{1} chats:{2} date:{3} seq:{4})", updates, users, chats, date, seq);
        }
    }

    public class UpdateShortSentMessageConstructor : Updates
    {
        public int flags;
        public int id;
        public int pts;
        public int pts_count;
        public int date;
        public MessageMedia media;
        public List<MessageEntity> entities;

        public UpdateShortSentMessageConstructor() { }

        public UpdateShortSentMessageConstructor(int flags, int id, int pts, int pts_count, int date, MessageMedia media, List<MessageEntity> entities)
        {
            this.flags = flags;
            this.id = id;
            this.pts = pts;
            this.pts_count = pts_count;
            this.date = date;
            this.media = media;
            this.entities = entities;
        }

        public override Constructor Constructor
        { get { return Constructor.updateShortSentMessage; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x11f1331c);
            // Calculate flags value
            flags = 0;
            if (media != null) flags += 512;
            if (entities != null) flags += 128;

            writer.Write(flags);
            writer.Write(id);
            writer.Write(pts);
            writer.Write(pts_count);
            writer.Write(date);
            if (media != null)
            {
                media.Write(writer);
            }
            if (entities != null)
            {
                writer.Write(0x1cb5c415); // vector code
                writer.Write(entities.Count);
                foreach (MessageEntity entities_element in entities)
                    entities_element.Write(writer);
            }
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            id = reader.ReadInt32();
            pts = reader.ReadInt32();
            pts_count = reader.ReadInt32();
            date = reader.ReadInt32();
            if ((flags & 512) != 0)
            {
                media = TL.Parse<MessageMedia>(reader);
            }
            if ((flags & 128) != 0)
            {
                reader.ReadUInt32(); // vector code
                int entities_count = reader.ReadInt32();
                entities = new List<MessageEntity>(entities_count);
                for (int entities_index = 0; entities_index < entities_count; entities_index++)
                    entities.Add(TL.Parse<MessageEntity>(reader));
            }
        }

        public override string ToString()
        {
            return string.Format("(updateShortSentMessage flags:{0} id:{1} pts:{2} pts_count:{3} date:{4} media:{5} entities:{6})", flags, id, pts, pts_count, date, media, entities);
        }
    }

    public class Photos_photosConstructor : photos_Photos
    {
        public List<Photo> photos;
        public List<User> users;

        public Photos_photosConstructor() { }

        public Photos_photosConstructor(List<Photo> photos, List<User> users)
        {
            this.photos = photos;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.photos_photos; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x8dca6aa5);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(photos.Count);
            foreach (Photo photos_element in photos)
                photos_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int photos_count = reader.ReadInt32();
            photos = new List<Photo>(photos_count);
            for (int photos_index = 0; photos_index < photos_count; photos_index++)
                photos.Add(TL.Parse<Photo>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(photos_photos photos:{0} users:{1})", photos, users);
        }
    }

    public class Photos_photosSliceConstructor : photos_Photos
    {
        public int count;
        public List<Photo> photos;
        public List<User> users;

        public Photos_photosSliceConstructor() { }

        public Photos_photosSliceConstructor(int count, List<Photo> photos, List<User> users)
        {
            this.count = count;
            this.photos = photos;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.photos_photosSlice; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x15051f54);
            writer.Write(count);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(photos.Count);
            foreach (Photo photos_element in photos)
                photos_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            count = reader.ReadInt32();
            reader.ReadUInt32(); // vector code
            int photos_count = reader.ReadInt32();
            photos = new List<Photo>(photos_count);
            for (int photos_index = 0; photos_index < photos_count; photos_index++)
                photos.Add(TL.Parse<Photo>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(photos_photosSlice count:{0} photos:{1} users:{2})", count, photos, users);
        }
    }

    public class Photos_photoConstructor : photos_Photo
    {
        public Photo photo;
        public List<User> users;

        public Photos_photoConstructor() { }

        public Photos_photoConstructor(Photo photo, List<User> users)
        {
            this.photo = photo;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.photos_photo; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x20212ca8);
            photo.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            photo = TL.Parse<Photo>(reader);
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(photos_photo photo:{0} users:{1})", photo, users);
        }
    }

    public class Upload_fileConstructor : upload_File
    {
        public storage_FileType type;
        public int mtime;
        public byte[] bytes;

        public Upload_fileConstructor() { }

        public Upload_fileConstructor(storage_FileType type, int mtime, byte[] bytes)
        {
            this.type = type;
            this.mtime = mtime;
            this.bytes = bytes;
        }

        public override Constructor Constructor
        { get { return Constructor.upload_file; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x96a18d5);
            type.Write(writer);
            writer.Write(mtime);
            Serializers.Bytes.Write(writer, bytes);
        }

        public override void Read(BinaryReader reader)
        {
            type = TL.Parse<storage_FileType>(reader);
            mtime = reader.ReadInt32();
            bytes = Serializers.Bytes.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(upload_file type:{0} mtime:{1} bytes:{2})", type, mtime, bytes);
        }
    }

    public class DcOptionConstructor : DcOption
    {
        public int flags;
        public int id;
        public string ip_address;
        public int port;

        public DcOptionConstructor() { }

        public DcOptionConstructor(int flags, int id, string ip_address, int port)
        {
            this.flags = flags;
            this.id = id;
            this.ip_address = ip_address;
            this.port = port;
        }

        public override Constructor Constructor
        { get { return Constructor.dcOption; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5d8c6cc);
            // Calculate flags value
            flags = 0;

            writer.Write(flags);
            writer.Write(id);
            Serializers.String.Write(writer, ip_address);
            writer.Write(port);
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            id = reader.ReadInt32();
            ip_address = Serializers.String.Read(reader);
            port = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(dcOption flags:{0} id:{1} ip_address:{2} port:{3})", flags, id, ip_address, port);
        }
    }

    public class ConfigConstructor : Config
    {
        public int date;
        public int expires;
        public bool test_mode;
        public int this_dc;
        public List<DcOption> dc_options;
        public int chat_size_max;
        public int broadcast_size_max;
        public int forwarded_count_max;
        public int online_update_period_ms;
        public int offline_blur_timeout_ms;
        public int offline_idle_timeout_ms;
        public int online_cloud_timeout_ms;
        public int notify_cloud_delay_ms;
        public int notify_default_delay_ms;
        public int chat_big_size;
        public int push_chat_period_ms;
        public int push_chat_limit;
        public List<DisabledFeature> disabled_features;

        public ConfigConstructor() { }

        public ConfigConstructor(int date, int expires, bool test_mode, int this_dc, List<DcOption> dc_options, int chat_size_max, int broadcast_size_max, int forwarded_count_max, int online_update_period_ms, int offline_blur_timeout_ms, int offline_idle_timeout_ms, int online_cloud_timeout_ms, int notify_cloud_delay_ms, int notify_default_delay_ms, int chat_big_size, int push_chat_period_ms, int push_chat_limit, List<DisabledFeature> disabled_features)
        {
            this.date = date;
            this.expires = expires;
            this.test_mode = test_mode;
            this.this_dc = this_dc;
            this.dc_options = dc_options;
            this.chat_size_max = chat_size_max;
            this.broadcast_size_max = broadcast_size_max;
            this.forwarded_count_max = forwarded_count_max;
            this.online_update_period_ms = online_update_period_ms;
            this.offline_blur_timeout_ms = offline_blur_timeout_ms;
            this.offline_idle_timeout_ms = offline_idle_timeout_ms;
            this.online_cloud_timeout_ms = online_cloud_timeout_ms;
            this.notify_cloud_delay_ms = notify_cloud_delay_ms;
            this.notify_default_delay_ms = notify_default_delay_ms;
            this.chat_big_size = chat_big_size;
            this.push_chat_period_ms = push_chat_period_ms;
            this.push_chat_limit = push_chat_limit;
            this.disabled_features = disabled_features;
        }

        public override Constructor Constructor
        { get { return Constructor.config; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4e32b894);
            writer.Write(date);
            writer.Write(expires);
            writer.Write(test_mode ? 0x997275b5 : 0xbc799737);
            writer.Write(this_dc);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(dc_options.Count);
            foreach (DcOption dc_options_element in dc_options)
                dc_options_element.Write(writer);
            writer.Write(chat_size_max);
            writer.Write(broadcast_size_max);
            writer.Write(forwarded_count_max);
            writer.Write(online_update_period_ms);
            writer.Write(offline_blur_timeout_ms);
            writer.Write(offline_idle_timeout_ms);
            writer.Write(online_cloud_timeout_ms);
            writer.Write(notify_cloud_delay_ms);
            writer.Write(notify_default_delay_ms);
            writer.Write(chat_big_size);
            writer.Write(push_chat_period_ms);
            writer.Write(push_chat_limit);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(disabled_features.Count);
            foreach (DisabledFeature disabled_features_element in disabled_features)
                disabled_features_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            date = reader.ReadInt32();
            expires = reader.ReadInt32();
            test_mode = reader.ReadUInt32() == 0x997275b5;
            this_dc = reader.ReadInt32();
            reader.ReadUInt32(); // vector code
            int dc_options_count = reader.ReadInt32();
            dc_options = new List<DcOption>(dc_options_count);
            for (int dc_options_index = 0; dc_options_index < dc_options_count; dc_options_index++)
                dc_options.Add(TL.Parse<DcOption>(reader));
            chat_size_max = reader.ReadInt32();
            broadcast_size_max = reader.ReadInt32();
            forwarded_count_max = reader.ReadInt32();
            online_update_period_ms = reader.ReadInt32();
            offline_blur_timeout_ms = reader.ReadInt32();
            offline_idle_timeout_ms = reader.ReadInt32();
            online_cloud_timeout_ms = reader.ReadInt32();
            notify_cloud_delay_ms = reader.ReadInt32();
            notify_default_delay_ms = reader.ReadInt32();
            chat_big_size = reader.ReadInt32();
            push_chat_period_ms = reader.ReadInt32();
            push_chat_limit = reader.ReadInt32();
            reader.ReadUInt32(); // vector code
            int disabled_features_count = reader.ReadInt32();
            disabled_features = new List<DisabledFeature>(disabled_features_count);
            for (int disabled_features_index = 0; disabled_features_index < disabled_features_count; disabled_features_index++)
                disabled_features.Add(TL.Parse<DisabledFeature>(reader));
        }

        public override string ToString()
        {
            return string.Format("(config date:{0} expires:{1} test_mode:{2} this_dc:{3} dc_options:{4} chat_size_max:{5} broadcast_size_max:{6} forwarded_count_max:{7} online_update_period_ms:{8} offline_blur_timeout_ms:{9} offline_idle_timeout_ms:{10} online_cloud_timeout_ms:{11} notify_cloud_delay_ms:{12} notify_default_delay_ms:{13} chat_big_size:{14} push_chat_period_ms:{15} push_chat_limit:{16} disabled_features:{17})", date, expires, test_mode, this_dc, dc_options, chat_size_max, broadcast_size_max, forwarded_count_max, online_update_period_ms, offline_blur_timeout_ms, offline_idle_timeout_ms, online_cloud_timeout_ms, notify_cloud_delay_ms, notify_default_delay_ms, chat_big_size, push_chat_period_ms, push_chat_limit, disabled_features);
        }
    }

    public class NearestDcConstructor : NearestDc
    {
        public string country;
        public int this_dc;
        public int nearest_dc;

        public NearestDcConstructor() { }

        public NearestDcConstructor(string country, int this_dc, int nearest_dc)
        {
            this.country = country;
            this.this_dc = this_dc;
            this.nearest_dc = nearest_dc;
        }

        public override Constructor Constructor
        { get { return Constructor.nearestDc; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x8e1a1775);
            Serializers.String.Write(writer, country);
            writer.Write(this_dc);
            writer.Write(nearest_dc);
        }

        public override void Read(BinaryReader reader)
        {
            country = Serializers.String.Read(reader);
            this_dc = reader.ReadInt32();
            nearest_dc = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(nearestDc country:{0} this_dc:{1} nearest_dc:{2})", country, this_dc, nearest_dc);
        }
    }

    public class Help_appUpdateConstructor : help_AppUpdate
    {
        public int id;
        public bool critical;
        public string url;
        public string text;

        public Help_appUpdateConstructor() { }

        public Help_appUpdateConstructor(int id, bool critical, string url, string text)
        {
            this.id = id;
            this.critical = critical;
            this.url = url;
            this.text = text;
        }

        public override Constructor Constructor
        { get { return Constructor.help_appUpdate; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x8987f311);
            writer.Write(id);
            writer.Write(critical ? 0x997275b5 : 0xbc799737);
            Serializers.String.Write(writer, url);
            Serializers.String.Write(writer, text);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt32();
            critical = reader.ReadUInt32() == 0x997275b5;
            url = Serializers.String.Read(reader);
            text = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(help_appUpdate id:{0} critical:{1} url:{2} text:{3})", id, critical, url, text);
        }
    }

    public class Help_noAppUpdateConstructor : help_AppUpdate
    {
        public Help_noAppUpdateConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.help_noAppUpdate; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc45a6536);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(help_noAppUpdate)");
        }
    }

    public class Help_inviteTextConstructor : help_InviteText
    {
        public string message;

        public Help_inviteTextConstructor() { }

        public Help_inviteTextConstructor(string message)
        {
            this.message = message;
        }

        public override Constructor Constructor
        { get { return Constructor.help_inviteText; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x18cb9f78);
            Serializers.String.Write(writer, message);
        }

        public override void Read(BinaryReader reader)
        {
            message = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(help_inviteText message:{0})", message);
        }
    }

    public class EncryptedChatEmptyConstructor : EncryptedChat
    {
        public int id;

        public EncryptedChatEmptyConstructor() { }

        public EncryptedChatEmptyConstructor(int id)
        {
            this.id = id;
        }

        public override Constructor Constructor
        { get { return Constructor.encryptedChatEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xab7ec0a0);
            writer.Write(id);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(encryptedChatEmpty id:{0})", id);
        }
    }

    public class EncryptedChatWaitingConstructor : EncryptedChat
    {
        public int id;
        public long access_hash;
        public int date;
        public int admin_id;
        public int participant_id;

        public EncryptedChatWaitingConstructor() { }

        public EncryptedChatWaitingConstructor(int id, long access_hash, int date, int admin_id, int participant_id)
        {
            this.id = id;
            this.access_hash = access_hash;
            this.date = date;
            this.admin_id = admin_id;
            this.participant_id = participant_id;
        }

        public override Constructor Constructor
        { get { return Constructor.encryptedChatWaiting; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x3bf703dc);
            writer.Write(id);
            writer.Write(access_hash);
            writer.Write(date);
            writer.Write(admin_id);
            writer.Write(participant_id);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt32();
            access_hash = reader.ReadInt64();
            date = reader.ReadInt32();
            admin_id = reader.ReadInt32();
            participant_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(encryptedChatWaiting id:{0} access_hash:{1} date:{2} admin_id:{3} participant_id:{4})", id, access_hash, date, admin_id, participant_id);
        }
    }

    public class EncryptedChatRequestedConstructor : EncryptedChat
    {
        public int id;
        public long access_hash;
        public int date;
        public int admin_id;
        public int participant_id;
        public byte[] g_a;

        public EncryptedChatRequestedConstructor() { }

        public EncryptedChatRequestedConstructor(int id, long access_hash, int date, int admin_id, int participant_id, byte[] g_a)
        {
            this.id = id;
            this.access_hash = access_hash;
            this.date = date;
            this.admin_id = admin_id;
            this.participant_id = participant_id;
            this.g_a = g_a;
        }

        public override Constructor Constructor
        { get { return Constructor.encryptedChatRequested; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc878527e);
            writer.Write(id);
            writer.Write(access_hash);
            writer.Write(date);
            writer.Write(admin_id);
            writer.Write(participant_id);
            Serializers.Bytes.Write(writer, g_a);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt32();
            access_hash = reader.ReadInt64();
            date = reader.ReadInt32();
            admin_id = reader.ReadInt32();
            participant_id = reader.ReadInt32();
            g_a = Serializers.Bytes.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(encryptedChatRequested id:{0} access_hash:{1} date:{2} admin_id:{3} participant_id:{4} g_a:{5})", id, access_hash, date, admin_id, participant_id, g_a);
        }
    }

    public class EncryptedChatConstructor : EncryptedChat
    {
        public int id;
        public long access_hash;
        public int date;
        public int admin_id;
        public int participant_id;
        public byte[] g_a_or_b;
        public long key_fingerprint;

        public EncryptedChatConstructor() { }

        public EncryptedChatConstructor(int id, long access_hash, int date, int admin_id, int participant_id, byte[] g_a_or_b, long key_fingerprint)
        {
            this.id = id;
            this.access_hash = access_hash;
            this.date = date;
            this.admin_id = admin_id;
            this.participant_id = participant_id;
            this.g_a_or_b = g_a_or_b;
            this.key_fingerprint = key_fingerprint;
        }

        public override Constructor Constructor
        { get { return Constructor.encryptedChat; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xfa56ce36);
            writer.Write(id);
            writer.Write(access_hash);
            writer.Write(date);
            writer.Write(admin_id);
            writer.Write(participant_id);
            Serializers.Bytes.Write(writer, g_a_or_b);
            writer.Write(key_fingerprint);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt32();
            access_hash = reader.ReadInt64();
            date = reader.ReadInt32();
            admin_id = reader.ReadInt32();
            participant_id = reader.ReadInt32();
            g_a_or_b = Serializers.Bytes.Read(reader);
            key_fingerprint = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(encryptedChat id:{0} access_hash:{1} date:{2} admin_id:{3} participant_id:{4} g_a_or_b:{5} key_fingerprint:{6})", id, access_hash, date, admin_id, participant_id, g_a_or_b, key_fingerprint);
        }
    }

    public class EncryptedChatDiscardedConstructor : EncryptedChat
    {
        public int id;

        public EncryptedChatDiscardedConstructor() { }

        public EncryptedChatDiscardedConstructor(int id)
        {
            this.id = id;
        }

        public override Constructor Constructor
        { get { return Constructor.encryptedChatDiscarded; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x13d6dd27);
            writer.Write(id);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(encryptedChatDiscarded id:{0})", id);
        }
    }

    public class InputEncryptedChatConstructor : InputEncryptedChat
    {
        public int chat_id;
        public long access_hash;

        public InputEncryptedChatConstructor() { }

        public InputEncryptedChatConstructor(int chat_id, long access_hash)
        {
            this.chat_id = chat_id;
            this.access_hash = access_hash;
        }

        public override Constructor Constructor
        { get { return Constructor.inputEncryptedChat; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf141b5e1);
            writer.Write(chat_id);
            writer.Write(access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            chat_id = reader.ReadInt32();
            access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(inputEncryptedChat chat_id:{0} access_hash:{1})", chat_id, access_hash);
        }
    }

    public class EncryptedFileEmptyConstructor : EncryptedFile
    {
        public EncryptedFileEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.encryptedFileEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc21f497e);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(encryptedFileEmpty)");
        }
    }

    public class EncryptedFileConstructor : EncryptedFile
    {
        public long id;
        public long access_hash;
        public int size;
        public int dc_id;
        public int key_fingerprint;

        public EncryptedFileConstructor() { }

        public EncryptedFileConstructor(long id, long access_hash, int size, int dc_id, int key_fingerprint)
        {
            this.id = id;
            this.access_hash = access_hash;
            this.size = size;
            this.dc_id = dc_id;
            this.key_fingerprint = key_fingerprint;
        }

        public override Constructor Constructor
        { get { return Constructor.encryptedFile; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4a70994c);
            writer.Write(id);
            writer.Write(access_hash);
            writer.Write(size);
            writer.Write(dc_id);
            writer.Write(key_fingerprint);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            access_hash = reader.ReadInt64();
            size = reader.ReadInt32();
            dc_id = reader.ReadInt32();
            key_fingerprint = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(encryptedFile id:{0} access_hash:{1} size:{2} dc_id:{3} key_fingerprint:{4})", id, access_hash, size, dc_id, key_fingerprint);
        }
    }

    public class InputEncryptedFileEmptyConstructor : InputEncryptedFile
    {
        public InputEncryptedFileEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputEncryptedFileEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1837c364);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputEncryptedFileEmpty)");
        }
    }

    public class InputEncryptedFileUploadedConstructor : InputEncryptedFile
    {
        public long id;
        public int parts;
        public string md5_checksum;
        public int key_fingerprint;

        public InputEncryptedFileUploadedConstructor() { }

        public InputEncryptedFileUploadedConstructor(long id, int parts, string md5_checksum, int key_fingerprint)
        {
            this.id = id;
            this.parts = parts;
            this.md5_checksum = md5_checksum;
            this.key_fingerprint = key_fingerprint;
        }

        public override Constructor Constructor
        { get { return Constructor.inputEncryptedFileUploaded; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x64bd0306);
            writer.Write(id);
            writer.Write(parts);
            Serializers.String.Write(writer, md5_checksum);
            writer.Write(key_fingerprint);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            parts = reader.ReadInt32();
            md5_checksum = Serializers.String.Read(reader);
            key_fingerprint = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(inputEncryptedFileUploaded id:{0} parts:{1} md5_checksum:{2} key_fingerprint:{3})", id, parts, md5_checksum, key_fingerprint);
        }
    }

    public class InputEncryptedFileConstructor : InputEncryptedFile
    {
        public long id;
        public long access_hash;

        public InputEncryptedFileConstructor() { }

        public InputEncryptedFileConstructor(long id, long access_hash)
        {
            this.id = id;
            this.access_hash = access_hash;
        }

        public override Constructor Constructor
        { get { return Constructor.inputEncryptedFile; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5a17b5e5);
            writer.Write(id);
            writer.Write(access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(inputEncryptedFile id:{0} access_hash:{1})", id, access_hash);
        }
    }

    public class InputEncryptedFileBigUploadedConstructor : InputEncryptedFile
    {
        public long id;
        public int parts;
        public int key_fingerprint;

        public InputEncryptedFileBigUploadedConstructor() { }

        public InputEncryptedFileBigUploadedConstructor(long id, int parts, int key_fingerprint)
        {
            this.id = id;
            this.parts = parts;
            this.key_fingerprint = key_fingerprint;
        }

        public override Constructor Constructor
        { get { return Constructor.inputEncryptedFileBigUploaded; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2dc173c8);
            writer.Write(id);
            writer.Write(parts);
            writer.Write(key_fingerprint);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            parts = reader.ReadInt32();
            key_fingerprint = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(inputEncryptedFileBigUploaded id:{0} parts:{1} key_fingerprint:{2})", id, parts, key_fingerprint);
        }
    }

    public class EncryptedMessageConstructor : EncryptedMessage
    {
        public long random_id;
        public int chat_id;
        public int date;
        public byte[] bytes;
        public EncryptedFile file;

        public EncryptedMessageConstructor() { }

        public EncryptedMessageConstructor(long random_id, int chat_id, int date, byte[] bytes, EncryptedFile file)
        {
            this.random_id = random_id;
            this.chat_id = chat_id;
            this.date = date;
            this.bytes = bytes;
            this.file = file;
        }

        public override Constructor Constructor
        { get { return Constructor.encryptedMessage; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xed18c118);
            writer.Write(random_id);
            writer.Write(chat_id);
            writer.Write(date);
            Serializers.Bytes.Write(writer, bytes);
            file.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            random_id = reader.ReadInt64();
            chat_id = reader.ReadInt32();
            date = reader.ReadInt32();
            bytes = Serializers.Bytes.Read(reader);
            file = TL.Parse<EncryptedFile>(reader);
        }

        public override string ToString()
        {
            return string.Format("(encryptedMessage random_id:{0} chat_id:{1} date:{2} bytes:{3} file:{4})", random_id, chat_id, date, bytes, file);
        }
    }

    public class EncryptedMessageServiceConstructor : EncryptedMessage
    {
        public long random_id;
        public int chat_id;
        public int date;
        public byte[] bytes;

        public EncryptedMessageServiceConstructor() { }

        public EncryptedMessageServiceConstructor(long random_id, int chat_id, int date, byte[] bytes)
        {
            this.random_id = random_id;
            this.chat_id = chat_id;
            this.date = date;
            this.bytes = bytes;
        }

        public override Constructor Constructor
        { get { return Constructor.encryptedMessageService; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x23734b06);
            writer.Write(random_id);
            writer.Write(chat_id);
            writer.Write(date);
            Serializers.Bytes.Write(writer, bytes);
        }

        public override void Read(BinaryReader reader)
        {
            random_id = reader.ReadInt64();
            chat_id = reader.ReadInt32();
            date = reader.ReadInt32();
            bytes = Serializers.Bytes.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(encryptedMessageService random_id:{0} chat_id:{1} date:{2} bytes:{3})", random_id, chat_id, date, bytes);
        }
    }

    public class Messages_dhConfigNotModifiedConstructor : messages_DhConfig
    {
        public byte[] random;

        public Messages_dhConfigNotModifiedConstructor() { }

        public Messages_dhConfigNotModifiedConstructor(byte[] random)
        {
            this.random = random;
        }

        public override Constructor Constructor
        { get { return Constructor.messages_dhConfigNotModified; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc0e24635);
            Serializers.Bytes.Write(writer, random);
        }

        public override void Read(BinaryReader reader)
        {
            random = Serializers.Bytes.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(messages_dhConfigNotModified random:{0})", random);
        }
    }

    public class Messages_dhConfigConstructor : messages_DhConfig
    {
        public int g;
        public byte[] p;
        public int version;
        public byte[] random;

        public Messages_dhConfigConstructor() { }

        public Messages_dhConfigConstructor(int g, byte[] p, int version, byte[] random)
        {
            this.g = g;
            this.p = p;
            this.version = version;
            this.random = random;
        }

        public override Constructor Constructor
        { get { return Constructor.messages_dhConfig; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2c221edd);
            writer.Write(g);
            Serializers.Bytes.Write(writer, p);
            writer.Write(version);
            Serializers.Bytes.Write(writer, random);
        }

        public override void Read(BinaryReader reader)
        {
            g = reader.ReadInt32();
            p = Serializers.Bytes.Read(reader);
            version = reader.ReadInt32();
            random = Serializers.Bytes.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(messages_dhConfig g:{0} p:{1} version:{2} random:{3})", g, p, version, random);
        }
    }

    public class Messages_sentEncryptedMessageConstructor : messages_SentEncryptedMessage
    {
        public int date;

        public Messages_sentEncryptedMessageConstructor() { }

        public Messages_sentEncryptedMessageConstructor(int date)
        {
            this.date = date;
        }

        public override Constructor Constructor
        { get { return Constructor.messages_sentEncryptedMessage; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x560f8935);
            writer.Write(date);
        }

        public override void Read(BinaryReader reader)
        {
            date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messages_sentEncryptedMessage date:{0})", date);
        }
    }

    public class Messages_sentEncryptedFileConstructor : messages_SentEncryptedMessage
    {
        public int date;
        public EncryptedFile file;

        public Messages_sentEncryptedFileConstructor() { }

        public Messages_sentEncryptedFileConstructor(int date, EncryptedFile file)
        {
            this.date = date;
            this.file = file;
        }

        public override Constructor Constructor
        { get { return Constructor.messages_sentEncryptedFile; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9493ff32);
            writer.Write(date);
            file.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            date = reader.ReadInt32();
            file = TL.Parse<EncryptedFile>(reader);
        }

        public override string ToString()
        {
            return string.Format("(messages_sentEncryptedFile date:{0} file:{1})", date, file);
        }
    }

    public class InputAudioEmptyConstructor : InputAudio
    {
        public InputAudioEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputAudioEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd95adc84);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputAudioEmpty)");
        }
    }

    public class InputAudioConstructor : InputAudio
    {
        public long id;
        public long access_hash;

        public InputAudioConstructor() { }

        public InputAudioConstructor(long id, long access_hash)
        {
            this.id = id;
            this.access_hash = access_hash;
        }

        public override Constructor Constructor
        { get { return Constructor.inputAudio; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x77d440ff);
            writer.Write(id);
            writer.Write(access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(inputAudio id:{0} access_hash:{1})", id, access_hash);
        }
    }

    public class InputDocumentEmptyConstructor : InputDocument
    {
        public InputDocumentEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputDocumentEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x72f0eaae);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputDocumentEmpty)");
        }
    }

    public class InputDocumentConstructor : InputDocument
    {
        public long id;
        public long access_hash;

        public InputDocumentConstructor() { }

        public InputDocumentConstructor(long id, long access_hash)
        {
            this.id = id;
            this.access_hash = access_hash;
        }

        public override Constructor Constructor
        { get { return Constructor.inputDocument; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x18798952);
            writer.Write(id);
            writer.Write(access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(inputDocument id:{0} access_hash:{1})", id, access_hash);
        }
    }

    public class AudioEmptyConstructor : Audio
    {
        public long id;

        public AudioEmptyConstructor() { }

        public AudioEmptyConstructor(long id)
        {
            this.id = id;
        }

        public override Constructor Constructor
        { get { return Constructor.audioEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x586988d8);
            writer.Write(id);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(audioEmpty id:{0})", id);
        }
    }

    public class AudioConstructor : Audio
    {
        public long id;
        public long access_hash;
        public int date;
        public int duration;
        public string mime_type;
        public int size;
        public int dc_id;

        public AudioConstructor() { }

        public AudioConstructor(long id, long access_hash, int date, int duration, string mime_type, int size, int dc_id)
        {
            this.id = id;
            this.access_hash = access_hash;
            this.date = date;
            this.duration = duration;
            this.mime_type = mime_type;
            this.size = size;
            this.dc_id = dc_id;
        }

        public override Constructor Constructor
        { get { return Constructor.audio; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf9e35055);
            writer.Write(id);
            writer.Write(access_hash);
            writer.Write(date);
            writer.Write(duration);
            Serializers.String.Write(writer, mime_type);
            writer.Write(size);
            writer.Write(dc_id);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            access_hash = reader.ReadInt64();
            date = reader.ReadInt32();
            duration = reader.ReadInt32();
            mime_type = Serializers.String.Read(reader);
            size = reader.ReadInt32();
            dc_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(audio id:{0} access_hash:{1} date:{2} duration:{3} mime_type:{4} size:{5} dc_id:{6})", id, access_hash, date, duration, mime_type, size, dc_id);
        }
    }

    public class DocumentEmptyConstructor : Document
    {
        public long id;

        public DocumentEmptyConstructor() { }

        public DocumentEmptyConstructor(long id)
        {
            this.id = id;
        }

        public override Constructor Constructor
        { get { return Constructor.documentEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x36f8c871);
            writer.Write(id);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(documentEmpty id:{0})", id);
        }
    }

    public class DocumentConstructor : Document
    {
        public long id;
        public long access_hash;
        public int date;
        public string mime_type;
        public int size;
        public PhotoSize thumb;
        public int dc_id;
        public List<DocumentAttribute> attributes;

        public DocumentConstructor() { }

        public DocumentConstructor(long id, long access_hash, int date, string mime_type, int size, PhotoSize thumb, int dc_id, List<DocumentAttribute> attributes)
        {
            this.id = id;
            this.access_hash = access_hash;
            this.date = date;
            this.mime_type = mime_type;
            this.size = size;
            this.thumb = thumb;
            this.dc_id = dc_id;
            this.attributes = attributes;
        }

        public override Constructor Constructor
        { get { return Constructor.document; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf9a39f4f);
            writer.Write(id);
            writer.Write(access_hash);
            writer.Write(date);
            Serializers.String.Write(writer, mime_type);
            writer.Write(size);
            thumb.Write(writer);
            writer.Write(dc_id);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(attributes.Count);
            foreach (DocumentAttribute attributes_element in attributes)
                attributes_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            access_hash = reader.ReadInt64();
            date = reader.ReadInt32();
            mime_type = Serializers.String.Read(reader);
            size = reader.ReadInt32();
            thumb = TL.Parse<PhotoSize>(reader);
            dc_id = reader.ReadInt32();
            reader.ReadUInt32(); // vector code
            int attributes_count = reader.ReadInt32();
            attributes = new List<DocumentAttribute>(attributes_count);
            for (int attributes_index = 0; attributes_index < attributes_count; attributes_index++)
                attributes.Add(TL.Parse<DocumentAttribute>(reader));
        }

        public override string ToString()
        {
            return string.Format("(document id:{0} access_hash:{1} date:{2} mime_type:{3} size:{4} thumb:{5} dc_id:{6} attributes:{7})", id, access_hash, date, mime_type, size, thumb, dc_id, attributes);
        }
    }

    public class Help_supportConstructor : help_Support
    {
        public string phone_number;
        public User user;

        public Help_supportConstructor() { }

        public Help_supportConstructor(string phone_number, User user)
        {
            this.phone_number = phone_number;
            this.user = user;
        }

        public override Constructor Constructor
        { get { return Constructor.help_support; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x17c6b5f6);
            Serializers.String.Write(writer, phone_number);
            user.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            phone_number = Serializers.String.Read(reader);
            user = TL.Parse<User>(reader);
        }

        public override string ToString()
        {
            return string.Format("(help_support phone_number:{0} user:{1})", phone_number, user);
        }
    }

    public class NotifyPeerConstructor : NotifyPeer
    {
        public Peer peer;

        public NotifyPeerConstructor() { }

        public NotifyPeerConstructor(Peer peer)
        {
            this.peer = peer;
        }

        public override Constructor Constructor
        { get { return Constructor.notifyPeer; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9fd40bd8);
            peer.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            peer = TL.Parse<Peer>(reader);
        }

        public override string ToString()
        {
            return string.Format("(notifyPeer peer:{0})", peer);
        }
    }

    public class NotifyUsersConstructor : NotifyPeer
    {
        public NotifyUsersConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.notifyUsers; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb4c83b4c);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(notifyUsers)");
        }
    }

    public class NotifyChatsConstructor : NotifyPeer
    {
        public NotifyChatsConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.notifyChats; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc007cec3);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(notifyChats)");
        }
    }

    public class NotifyAllConstructor : NotifyPeer
    {
        public NotifyAllConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.notifyAll; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x74d07c60);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(notifyAll)");
        }
    }

    public class SendMessageTypingActionConstructor : SendMessageAction
    {
        public SendMessageTypingActionConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.sendMessageTypingAction; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x16bf744e);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(sendMessageTypingAction)");
        }
    }

    public class SendMessageCancelActionConstructor : SendMessageAction
    {
        public SendMessageCancelActionConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.sendMessageCancelAction; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xfd5ec8f5);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(sendMessageCancelAction)");
        }
    }

    public class SendMessageRecordVideoActionConstructor : SendMessageAction
    {
        public SendMessageRecordVideoActionConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.sendMessageRecordVideoAction; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa187d66f);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(sendMessageRecordVideoAction)");
        }
    }

    public class SendMessageUploadVideoActionConstructor : SendMessageAction
    {
        public int progress;

        public SendMessageUploadVideoActionConstructor() { }

        public SendMessageUploadVideoActionConstructor(int progress)
        {
            this.progress = progress;
        }

        public override Constructor Constructor
        { get { return Constructor.sendMessageUploadVideoAction; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe9763aec);
            writer.Write(progress);
        }

        public override void Read(BinaryReader reader)
        {
            progress = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(sendMessageUploadVideoAction progress:{0})", progress);
        }
    }

    public class SendMessageRecordAudioActionConstructor : SendMessageAction
    {
        public SendMessageRecordAudioActionConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.sendMessageRecordAudioAction; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd52f73f7);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(sendMessageRecordAudioAction)");
        }
    }

    public class SendMessageUploadAudioActionConstructor : SendMessageAction
    {
        public int progress;

        public SendMessageUploadAudioActionConstructor() { }

        public SendMessageUploadAudioActionConstructor(int progress)
        {
            this.progress = progress;
        }

        public override Constructor Constructor
        { get { return Constructor.sendMessageUploadAudioAction; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf351d7ab);
            writer.Write(progress);
        }

        public override void Read(BinaryReader reader)
        {
            progress = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(sendMessageUploadAudioAction progress:{0})", progress);
        }
    }

    public class SendMessageUploadPhotoActionConstructor : SendMessageAction
    {
        public int progress;

        public SendMessageUploadPhotoActionConstructor() { }

        public SendMessageUploadPhotoActionConstructor(int progress)
        {
            this.progress = progress;
        }

        public override Constructor Constructor
        { get { return Constructor.sendMessageUploadPhotoAction; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd1d34a26);
            writer.Write(progress);
        }

        public override void Read(BinaryReader reader)
        {
            progress = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(sendMessageUploadPhotoAction progress:{0})", progress);
        }
    }

    public class SendMessageUploadDocumentActionConstructor : SendMessageAction
    {
        public int progress;

        public SendMessageUploadDocumentActionConstructor() { }

        public SendMessageUploadDocumentActionConstructor(int progress)
        {
            this.progress = progress;
        }

        public override Constructor Constructor
        { get { return Constructor.sendMessageUploadDocumentAction; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xaa0cd9e4);
            writer.Write(progress);
        }

        public override void Read(BinaryReader reader)
        {
            progress = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(sendMessageUploadDocumentAction progress:{0})", progress);
        }
    }

    public class SendMessageGeoLocationActionConstructor : SendMessageAction
    {
        public SendMessageGeoLocationActionConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.sendMessageGeoLocationAction; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x176f8ba1);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(sendMessageGeoLocationAction)");
        }
    }

    public class SendMessageChooseContactActionConstructor : SendMessageAction
    {
        public SendMessageChooseContactActionConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.sendMessageChooseContactAction; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x628cbc6f);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(sendMessageChooseContactAction)");
        }
    }

    public class Contacts_foundConstructor : contacts_Found
    {
        public List<Peer> results;
        public List<Chat> chats;
        public List<User> users;

        public Contacts_foundConstructor() { }

        public Contacts_foundConstructor(List<Peer> results, List<Chat> chats, List<User> users)
        {
            this.results = results;
            this.chats = chats;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.contacts_found; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1aa1f784);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(results.Count);
            foreach (Peer results_element in results)
                results_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(chats.Count);
            foreach (Chat chats_element in chats)
                chats_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int results_count = reader.ReadInt32();
            results = new List<Peer>(results_count);
            for (int results_index = 0; results_index < results_count; results_index++)
                results.Add(TL.Parse<Peer>(reader));
            reader.ReadUInt32(); // vector code
            int chats_count = reader.ReadInt32();
            chats = new List<Chat>(chats_count);
            for (int chats_index = 0; chats_index < chats_count; chats_index++)
                chats.Add(TL.Parse<Chat>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(contacts_found results:{0} chats:{1} users:{2})", results, chats, users);
        }
    }

    public class InputPrivacyKeyStatusTimestampConstructor : InputPrivacyKey
    {
        public InputPrivacyKeyStatusTimestampConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputPrivacyKeyStatusTimestamp; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4f96cb18);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputPrivacyKeyStatusTimestamp)");
        }
    }

    public class PrivacyKeyStatusTimestampConstructor : PrivacyKey
    {
        public PrivacyKeyStatusTimestampConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.privacyKeyStatusTimestamp; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xbc2eab30);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(privacyKeyStatusTimestamp)");
        }
    }

    public class InputPrivacyValueAllowContactsConstructor : InputPrivacyRule
    {
        public InputPrivacyValueAllowContactsConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputPrivacyValueAllowContacts; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd09e07b);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputPrivacyValueAllowContacts)");
        }
    }

    public class InputPrivacyValueAllowAllConstructor : InputPrivacyRule
    {
        public InputPrivacyValueAllowAllConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputPrivacyValueAllowAll; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x184b35ce);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputPrivacyValueAllowAll)");
        }
    }

    public class InputPrivacyValueAllowUsersConstructor : InputPrivacyRule
    {
        public List<InputUser> users;

        public InputPrivacyValueAllowUsersConstructor() { }

        public InputPrivacyValueAllowUsersConstructor(List<InputUser> users)
        {
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.inputPrivacyValueAllowUsers; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x131cc67f);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (InputUser users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<InputUser>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<InputUser>(reader));
        }

        public override string ToString()
        {
            return string.Format("(inputPrivacyValueAllowUsers users:{0})", users);
        }
    }

    public class InputPrivacyValueDisallowContactsConstructor : InputPrivacyRule
    {
        public InputPrivacyValueDisallowContactsConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputPrivacyValueDisallowContacts; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xba52007);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputPrivacyValueDisallowContacts)");
        }
    }

    public class InputPrivacyValueDisallowAllConstructor : InputPrivacyRule
    {
        public InputPrivacyValueDisallowAllConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputPrivacyValueDisallowAll; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd66b66c9);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputPrivacyValueDisallowAll)");
        }
    }

    public class InputPrivacyValueDisallowUsersConstructor : InputPrivacyRule
    {
        public List<InputUser> users;

        public InputPrivacyValueDisallowUsersConstructor() { }

        public InputPrivacyValueDisallowUsersConstructor(List<InputUser> users)
        {
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.inputPrivacyValueDisallowUsers; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x90110467);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (InputUser users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<InputUser>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<InputUser>(reader));
        }

        public override string ToString()
        {
            return string.Format("(inputPrivacyValueDisallowUsers users:{0})", users);
        }
    }

    public class PrivacyValueAllowContactsConstructor : PrivacyRule
    {
        public PrivacyValueAllowContactsConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.privacyValueAllowContacts; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xfffe1bac);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(privacyValueAllowContacts)");
        }
    }

    public class PrivacyValueAllowAllConstructor : PrivacyRule
    {
        public PrivacyValueAllowAllConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.privacyValueAllowAll; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x65427b82);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(privacyValueAllowAll)");
        }
    }

    public class PrivacyValueAllowUsersConstructor : PrivacyRule
    {
        public List<int> users;

        public PrivacyValueAllowUsersConstructor() { }

        public PrivacyValueAllowUsersConstructor(List<int> users)
        {
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.privacyValueAllowUsers; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4d5bbe0c);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (int users_element in users)
                writer.Write(users_element);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<int>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(reader.ReadInt32());
        }

        public override string ToString()
        {
            return string.Format("(privacyValueAllowUsers users:{0})", users);
        }
    }

    public class PrivacyValueDisallowContactsConstructor : PrivacyRule
    {
        public PrivacyValueDisallowContactsConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.privacyValueDisallowContacts; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf888fa1a);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(privacyValueDisallowContacts)");
        }
    }

    public class PrivacyValueDisallowAllConstructor : PrivacyRule
    {
        public PrivacyValueDisallowAllConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.privacyValueDisallowAll; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x8b73e763);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(privacyValueDisallowAll)");
        }
    }

    public class PrivacyValueDisallowUsersConstructor : PrivacyRule
    {
        public List<int> users;

        public PrivacyValueDisallowUsersConstructor() { }

        public PrivacyValueDisallowUsersConstructor(List<int> users)
        {
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.privacyValueDisallowUsers; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc7f49b7);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (int users_element in users)
                writer.Write(users_element);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<int>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(reader.ReadInt32());
        }

        public override string ToString()
        {
            return string.Format("(privacyValueDisallowUsers users:{0})", users);
        }
    }

    public class Account_privacyRulesConstructor : account_PrivacyRules
    {
        public List<PrivacyRule> rules;
        public List<User> users;

        public Account_privacyRulesConstructor() { }

        public Account_privacyRulesConstructor(List<PrivacyRule> rules, List<User> users)
        {
            this.rules = rules;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.account_privacyRules; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x554abb6f);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(rules.Count);
            foreach (PrivacyRule rules_element in rules)
                rules_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int rules_count = reader.ReadInt32();
            rules = new List<PrivacyRule>(rules_count);
            for (int rules_index = 0; rules_index < rules_count; rules_index++)
                rules.Add(TL.Parse<PrivacyRule>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(account_privacyRules rules:{0} users:{1})", rules, users);
        }
    }

    public class AccountDaysTTLConstructor : AccountDaysTTL
    {
        public int days;

        public AccountDaysTTLConstructor() { }

        public AccountDaysTTLConstructor(int days)
        {
            this.days = days;
        }

        public override Constructor Constructor
        { get { return Constructor.accountDaysTTL; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb8d0afdf);
            writer.Write(days);
        }

        public override void Read(BinaryReader reader)
        {
            days = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(accountDaysTTL days:{0})", days);
        }
    }

    public class Account_sentChangePhoneCodeConstructor : account_SentChangePhoneCode
    {
        public string phone_code_hash;
        public int send_call_timeout;

        public Account_sentChangePhoneCodeConstructor() { }

        public Account_sentChangePhoneCodeConstructor(string phone_code_hash, int send_call_timeout)
        {
            this.phone_code_hash = phone_code_hash;
            this.send_call_timeout = send_call_timeout;
        }

        public override Constructor Constructor
        { get { return Constructor.account_sentChangePhoneCode; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa4f58c4c);
            Serializers.String.Write(writer, phone_code_hash);
            writer.Write(send_call_timeout);
        }

        public override void Read(BinaryReader reader)
        {
            phone_code_hash = Serializers.String.Read(reader);
            send_call_timeout = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(account_sentChangePhoneCode phone_code_hash:{0} send_call_timeout:{1})", phone_code_hash, send_call_timeout);
        }
    }

    public class DocumentAttributeImageSizeConstructor : DocumentAttribute
    {
        public int w;
        public int h;

        public DocumentAttributeImageSizeConstructor() { }

        public DocumentAttributeImageSizeConstructor(int w, int h)
        {
            this.w = w;
            this.h = h;
        }

        public override Constructor Constructor
        { get { return Constructor.documentAttributeImageSize; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6c37c15c);
            writer.Write(w);
            writer.Write(h);
        }

        public override void Read(BinaryReader reader)
        {
            w = reader.ReadInt32();
            h = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(documentAttributeImageSize w:{0} h:{1})", w, h);
        }
    }

    public class DocumentAttributeAnimatedConstructor : DocumentAttribute
    {
        public DocumentAttributeAnimatedConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.documentAttributeAnimated; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x11b58939);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(documentAttributeAnimated)");
        }
    }

    public class DocumentAttributeStickerConstructor : DocumentAttribute
    {
        public string alt;
        public InputStickerSet stickerset;

        public DocumentAttributeStickerConstructor() { }

        public DocumentAttributeStickerConstructor(string alt, InputStickerSet stickerset)
        {
            this.alt = alt;
            this.stickerset = stickerset;
        }

        public override Constructor Constructor
        { get { return Constructor.documentAttributeSticker; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x3a556302);
            Serializers.String.Write(writer, alt);
            stickerset.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            alt = Serializers.String.Read(reader);
            stickerset = TL.Parse<InputStickerSet>(reader);
        }

        public override string ToString()
        {
            return string.Format("(documentAttributeSticker alt:{0} stickerset:{1})", alt, stickerset);
        }
    }

    public class DocumentAttributeVideoConstructor : DocumentAttribute
    {
        public int duration;
        public int w;
        public int h;

        public DocumentAttributeVideoConstructor() { }

        public DocumentAttributeVideoConstructor(int duration, int w, int h)
        {
            this.duration = duration;
            this.w = w;
            this.h = h;
        }

        public override Constructor Constructor
        { get { return Constructor.documentAttributeVideo; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5910cccb);
            writer.Write(duration);
            writer.Write(w);
            writer.Write(h);
        }

        public override void Read(BinaryReader reader)
        {
            duration = reader.ReadInt32();
            w = reader.ReadInt32();
            h = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(documentAttributeVideo duration:{0} w:{1} h:{2})", duration, w, h);
        }
    }

    public class DocumentAttributeAudioConstructor : DocumentAttribute
    {
        public int duration;
        public string title;
        public string performer;

        public DocumentAttributeAudioConstructor() { }

        public DocumentAttributeAudioConstructor(int duration, string title, string performer)
        {
            this.duration = duration;
            this.title = title;
            this.performer = performer;
        }

        public override Constructor Constructor
        { get { return Constructor.documentAttributeAudio; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xded218e0);
            writer.Write(duration);
            Serializers.String.Write(writer, title);
            Serializers.String.Write(writer, performer);
        }

        public override void Read(BinaryReader reader)
        {
            duration = reader.ReadInt32();
            title = Serializers.String.Read(reader);
            performer = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(documentAttributeAudio duration:{0} title:{1} performer:{2})", duration, title, performer);
        }
    }

    public class DocumentAttributeFilenameConstructor : DocumentAttribute
    {
        public string file_name;

        public DocumentAttributeFilenameConstructor() { }

        public DocumentAttributeFilenameConstructor(string file_name)
        {
            this.file_name = file_name;
        }

        public override Constructor Constructor
        { get { return Constructor.documentAttributeFilename; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x15590068);
            Serializers.String.Write(writer, file_name);
        }

        public override void Read(BinaryReader reader)
        {
            file_name = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(documentAttributeFilename file_name:{0})", file_name);
        }
    }

    public class Messages_stickersNotModifiedConstructor : messages_Stickers
    {
        public Messages_stickersNotModifiedConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.messages_stickersNotModified; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf1749a22);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(messages_stickersNotModified)");
        }
    }

    public class Messages_stickersConstructor : messages_Stickers
    {
        public string hash;
        public List<Document> stickers;

        public Messages_stickersConstructor() { }

        public Messages_stickersConstructor(string hash, List<Document> stickers)
        {
            this.hash = hash;
            this.stickers = stickers;
        }

        public override Constructor Constructor
        { get { return Constructor.messages_stickers; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x8a8ecd32);
            Serializers.String.Write(writer, hash);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(stickers.Count);
            foreach (Document stickers_element in stickers)
                stickers_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            hash = Serializers.String.Read(reader);
            reader.ReadUInt32(); // vector code
            int stickers_count = reader.ReadInt32();
            stickers = new List<Document>(stickers_count);
            for (int stickers_index = 0; stickers_index < stickers_count; stickers_index++)
                stickers.Add(TL.Parse<Document>(reader));
        }

        public override string ToString()
        {
            return string.Format("(messages_stickers hash:{0} stickers:{1})", hash, stickers);
        }
    }

    public class StickerPackConstructor : StickerPack
    {
        public string emoticon;
        public List<long> documents;

        public StickerPackConstructor() { }

        public StickerPackConstructor(string emoticon, List<long> documents)
        {
            this.emoticon = emoticon;
            this.documents = documents;
        }

        public override Constructor Constructor
        { get { return Constructor.stickerPack; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x12b299d4);
            Serializers.String.Write(writer, emoticon);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(documents.Count);
            foreach (long documents_element in documents)
                writer.Write(documents_element);
        }

        public override void Read(BinaryReader reader)
        {
            emoticon = Serializers.String.Read(reader);
            reader.ReadUInt32(); // vector code
            int documents_count = reader.ReadInt32();
            documents = new List<long>(documents_count);
            for (int documents_index = 0; documents_index < documents_count; documents_index++)
                documents.Add(reader.ReadInt64());
        }

        public override string ToString()
        {
            return string.Format("(stickerPack emoticon:{0} documents:{1})", emoticon, documents);
        }
    }

    public class Messages_allStickersNotModifiedConstructor : messages_AllStickers
    {
        public Messages_allStickersNotModifiedConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.messages_allStickersNotModified; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe86602c3);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(messages_allStickersNotModified)");
        }
    }

    public class Messages_allStickersConstructor : messages_AllStickers
    {
        public string hash;
        public List<StickerSet> sets;

        public Messages_allStickersConstructor() { }

        public Messages_allStickersConstructor(string hash, List<StickerSet> sets)
        {
            this.hash = hash;
            this.sets = sets;
        }

        public override Constructor Constructor
        { get { return Constructor.messages_allStickers; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd51dafdb);
            Serializers.String.Write(writer, hash);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(sets.Count);
            foreach (StickerSet sets_element in sets)
                sets_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            hash = Serializers.String.Read(reader);
            reader.ReadUInt32(); // vector code
            int sets_count = reader.ReadInt32();
            sets = new List<StickerSet>(sets_count);
            for (int sets_index = 0; sets_index < sets_count; sets_index++)
                sets.Add(TL.Parse<StickerSet>(reader));
        }

        public override string ToString()
        {
            return string.Format("(messages_allStickers hash:{0} sets:{1})", hash, sets);
        }
    }

    public class DisabledFeatureConstructor : DisabledFeature
    {
        public string feature;
        public string description;

        public DisabledFeatureConstructor() { }

        public DisabledFeatureConstructor(string feature, string description)
        {
            this.feature = feature;
            this.description = description;
        }

        public override Constructor Constructor
        { get { return Constructor.disabledFeature; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xae636f24);
            Serializers.String.Write(writer, feature);
            Serializers.String.Write(writer, description);
        }

        public override void Read(BinaryReader reader)
        {
            feature = Serializers.String.Read(reader);
            description = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(disabledFeature feature:{0} description:{1})", feature, description);
        }
    }

    public class Messages_affectedMessagesConstructor : messages_AffectedMessages
    {
        public int pts;
        public int pts_count;

        public Messages_affectedMessagesConstructor() { }

        public Messages_affectedMessagesConstructor(int pts, int pts_count)
        {
            this.pts = pts;
            this.pts_count = pts_count;
        }

        public override Constructor Constructor
        { get { return Constructor.messages_affectedMessages; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x84d19185);
            writer.Write(pts);
            writer.Write(pts_count);
        }

        public override void Read(BinaryReader reader)
        {
            pts = reader.ReadInt32();
            pts_count = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messages_affectedMessages pts:{0} pts_count:{1})", pts, pts_count);
        }
    }

    public class ContactLinkUnknownConstructor : ContactLink
    {
        public ContactLinkUnknownConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.contactLinkUnknown; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5f4f9247);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(contactLinkUnknown)");
        }
    }

    public class ContactLinkNoneConstructor : ContactLink
    {
        public ContactLinkNoneConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.contactLinkNone; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xfeedd3ad);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(contactLinkNone)");
        }
    }

    public class ContactLinkHasPhoneConstructor : ContactLink
    {
        public ContactLinkHasPhoneConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.contactLinkHasPhone; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x268f3f59);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(contactLinkHasPhone)");
        }
    }

    public class ContactLinkContactConstructor : ContactLink
    {
        public ContactLinkContactConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.contactLinkContact; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd502c2d0);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(contactLinkContact)");
        }
    }

    public class WebPageEmptyConstructor : WebPage
    {
        public long id;

        public WebPageEmptyConstructor() { }

        public WebPageEmptyConstructor(long id)
        {
            this.id = id;
        }

        public override Constructor Constructor
        { get { return Constructor.webPageEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xeb1477e8);
            writer.Write(id);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(webPageEmpty id:{0})", id);
        }
    }

    public class WebPagePendingConstructor : WebPage
    {
        public long id;
        public int date;

        public WebPagePendingConstructor() { }

        public WebPagePendingConstructor(long id, int date)
        {
            this.id = id;
            this.date = date;
        }

        public override Constructor Constructor
        { get { return Constructor.webPagePending; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc586da1c);
            writer.Write(id);
            writer.Write(date);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(webPagePending id:{0} date:{1})", id, date);
        }
    }

    public class WebPageConstructor : WebPage
    {
        public int flags;
        public long id;
        public string url;
        public string display_url;
        public string type;
        public string site_name;
        public string title;
        public string description;
        public Photo photo;
        public string embed_url;
        public string embed_type;
        public int? embed_width;
        public int? embed_height;
        public int? duration;
        public string author;
        public Document document;

        public WebPageConstructor() { }

        public WebPageConstructor(int flags, long id, string url, string display_url, string type, string site_name, string title, string description, Photo photo, string embed_url, string embed_type, int? embed_width, int? embed_height, int? duration, string author, Document document)
        {
            this.flags = flags;
            this.id = id;
            this.url = url;
            this.display_url = display_url;
            this.type = type;
            this.site_name = site_name;
            this.title = title;
            this.description = description;
            this.photo = photo;
            this.embed_url = embed_url;
            this.embed_type = embed_type;
            this.embed_width = embed_width;
            this.embed_height = embed_height;
            this.duration = duration;
            this.author = author;
            this.document = document;
        }

        public override Constructor Constructor
        { get { return Constructor.webPage; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xca820ed7);
            // Calculate flags value
            flags = 0;
            if (type != null) flags += 1;
            if (site_name != null) flags += 2;
            if (title != null) flags += 4;
            if (description != null) flags += 8;
            if (photo != null) flags += 16;
            if (embed_url != null) flags += 32;
            if (embed_width != null) flags += 64;
            if (duration != null) flags += 128;
            if (author != null) flags += 256;
            if (document != null) flags += 512;

            writer.Write(flags);
            writer.Write(id);
            Serializers.String.Write(writer, url);
            Serializers.String.Write(writer, display_url);
            if (type != null)
            {
                Serializers.String.Write(writer, type);
            }
            if (site_name != null)
            {
                Serializers.String.Write(writer, site_name);
            }
            if (title != null)
            {
                Serializers.String.Write(writer, title);
            }
            if (description != null)
            {
                Serializers.String.Write(writer, description);
            }
            if (photo != null)
            {
                photo.Write(writer);
            }
            if (embed_url != null)
            {
                Serializers.String.Write(writer, embed_url);
            }
            if (embed_type != null)
            {
                Serializers.String.Write(writer, embed_type);
            }
            if (embed_width != null)
            {
                writer.Write(embed_width.Value);
            }
            if (embed_height != null)
            {
                writer.Write(embed_height.Value);
            }
            if (duration != null)
            {
                writer.Write(duration.Value);
            }
            if (author != null)
            {
                Serializers.String.Write(writer, author);
            }
            if (document != null)
            {
                document.Write(writer);
            }
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            id = reader.ReadInt64();
            url = Serializers.String.Read(reader);
            display_url = Serializers.String.Read(reader);
            if ((flags & 1) != 0)
            {
                type = Serializers.String.Read(reader);
            }
            if ((flags & 2) != 0)
            {
                site_name = Serializers.String.Read(reader);
            }
            if ((flags & 4) != 0)
            {
                title = Serializers.String.Read(reader);
            }
            if ((flags & 8) != 0)
            {
                description = Serializers.String.Read(reader);
            }
            if ((flags & 16) != 0)
            {
                photo = TL.Parse<Photo>(reader);
            }
            if ((flags & 32) != 0)
            {
                embed_url = Serializers.String.Read(reader);
            }
            if ((flags & 32) != 0)
            {
                embed_type = Serializers.String.Read(reader);
            }
            if ((flags & 64) != 0)
            {
                embed_width = reader.ReadInt32();
            }
            if ((flags & 64) != 0)
            {
                embed_height = reader.ReadInt32();
            }
            if ((flags & 128) != 0)
            {
                duration = reader.ReadInt32();
            }
            if ((flags & 256) != 0)
            {
                author = Serializers.String.Read(reader);
            }
            if ((flags & 512) != 0)
            {
                document = TL.Parse<Document>(reader);
            }
        }

        public override string ToString()
        {
            return string.Format("(webPage flags:{0} id:{1} url:{2} display_url:{3} type:{4} site_name:{5} title:{6} description:{7} photo:{8} embed_url:{9} embed_type:{10} embed_width:{11} embed_height:{12} duration:{13} author:{14} document:{15})", flags, id, url, display_url, type, site_name, title, description, photo, embed_url, embed_type, embed_width, embed_height, duration, author, document);
        }
    }

    public class AuthorizationConstructor : Authorization
    {
        public long hash;
        public int flags;
        public string device_model;
        public string platform;
        public string system_version;
        public int api_id;
        public string app_name;
        public string app_version;
        public int date_created;
        public int date_active;
        public string ip;
        public string country;
        public string region;

        public AuthorizationConstructor() { }

        public AuthorizationConstructor(long hash, int flags, string device_model, string platform, string system_version, int api_id, string app_name, string app_version, int date_created, int date_active, string ip, string country, string region)
        {
            this.hash = hash;
            this.flags = flags;
            this.device_model = device_model;
            this.platform = platform;
            this.system_version = system_version;
            this.api_id = api_id;
            this.app_name = app_name;
            this.app_version = app_version;
            this.date_created = date_created;
            this.date_active = date_active;
            this.ip = ip;
            this.country = country;
            this.region = region;
        }

        public override Constructor Constructor
        { get { return Constructor.authorization; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7bf2e6f6);
            writer.Write(hash);
            writer.Write(flags);
            Serializers.String.Write(writer, device_model);
            Serializers.String.Write(writer, platform);
            Serializers.String.Write(writer, system_version);
            writer.Write(api_id);
            Serializers.String.Write(writer, app_name);
            Serializers.String.Write(writer, app_version);
            writer.Write(date_created);
            writer.Write(date_active);
            Serializers.String.Write(writer, ip);
            Serializers.String.Write(writer, country);
            Serializers.String.Write(writer, region);
        }

        public override void Read(BinaryReader reader)
        {
            hash = reader.ReadInt64();
            flags = reader.ReadInt32();
            device_model = Serializers.String.Read(reader);
            platform = Serializers.String.Read(reader);
            system_version = Serializers.String.Read(reader);
            api_id = reader.ReadInt32();
            app_name = Serializers.String.Read(reader);
            app_version = Serializers.String.Read(reader);
            date_created = reader.ReadInt32();
            date_active = reader.ReadInt32();
            ip = Serializers.String.Read(reader);
            country = Serializers.String.Read(reader);
            region = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(authorization hash:{0} flags:{1} device_model:{2} platform:{3} system_version:{4} api_id:{5} app_name:{6} app_version:{7} date_created:{8} date_active:{9} ip:{10} country:{11} region:{12})", hash, flags, device_model, platform, system_version, api_id, app_name, app_version, date_created, date_active, ip, country, region);
        }
    }

    public class Account_authorizationsConstructor : account_Authorizations
    {
        public List<Authorization> authorizations;

        public Account_authorizationsConstructor() { }

        public Account_authorizationsConstructor(List<Authorization> authorizations)
        {
            this.authorizations = authorizations;
        }

        public override Constructor Constructor
        { get { return Constructor.account_authorizations; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x1250abde);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(authorizations.Count);
            foreach (Authorization authorizations_element in authorizations)
                authorizations_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int authorizations_count = reader.ReadInt32();
            authorizations = new List<Authorization>(authorizations_count);
            for (int authorizations_index = 0; authorizations_index < authorizations_count; authorizations_index++)
                authorizations.Add(TL.Parse<Authorization>(reader));
        }

        public override string ToString()
        {
            return string.Format("(account_authorizations authorizations:{0})", authorizations);
        }
    }

    public class Account_noPasswordConstructor : account_Password
    {
        public byte[] new_salt;
        public string email_unconfirmed_pattern;

        public Account_noPasswordConstructor() { }

        public Account_noPasswordConstructor(byte[] new_salt, string email_unconfirmed_pattern)
        {
            this.new_salt = new_salt;
            this.email_unconfirmed_pattern = email_unconfirmed_pattern;
        }

        public override Constructor Constructor
        { get { return Constructor.account_noPassword; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x96dabc18);
            Serializers.Bytes.Write(writer, new_salt);
            Serializers.String.Write(writer, email_unconfirmed_pattern);
        }

        public override void Read(BinaryReader reader)
        {
            new_salt = Serializers.Bytes.Read(reader);
            email_unconfirmed_pattern = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(account_noPassword new_salt:{0} email_unconfirmed_pattern:{1})", new_salt, email_unconfirmed_pattern);
        }
    }

    public class Account_passwordConstructor : account_Password
    {
        public byte[] current_salt;
        public byte[] new_salt;
        public string hint;
        public bool has_recovery;
        public string email_unconfirmed_pattern;

        public Account_passwordConstructor() { }

        public Account_passwordConstructor(byte[] current_salt, byte[] new_salt, string hint, bool has_recovery, string email_unconfirmed_pattern)
        {
            this.current_salt = current_salt;
            this.new_salt = new_salt;
            this.hint = hint;
            this.has_recovery = has_recovery;
            this.email_unconfirmed_pattern = email_unconfirmed_pattern;
        }

        public override Constructor Constructor
        { get { return Constructor.account_password; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7c18141c);
            Serializers.Bytes.Write(writer, current_salt);
            Serializers.Bytes.Write(writer, new_salt);
            Serializers.String.Write(writer, hint);
            writer.Write(has_recovery ? 0x997275b5 : 0xbc799737);
            Serializers.String.Write(writer, email_unconfirmed_pattern);
        }

        public override void Read(BinaryReader reader)
        {
            current_salt = Serializers.Bytes.Read(reader);
            new_salt = Serializers.Bytes.Read(reader);
            hint = Serializers.String.Read(reader);
            has_recovery = reader.ReadUInt32() == 0x997275b5;
            email_unconfirmed_pattern = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(account_password current_salt:{0} new_salt:{1} hint:{2} has_recovery:{3} email_unconfirmed_pattern:{4})", current_salt, new_salt, hint, has_recovery, email_unconfirmed_pattern);
        }
    }

    public class Account_passwordSettingsConstructor : account_PasswordSettings
    {
        public string email;

        public Account_passwordSettingsConstructor() { }

        public Account_passwordSettingsConstructor(string email)
        {
            this.email = email;
        }

        public override Constructor Constructor
        { get { return Constructor.account_passwordSettings; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb7b72ab3);
            Serializers.String.Write(writer, email);
        }

        public override void Read(BinaryReader reader)
        {
            email = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(account_passwordSettings email:{0})", email);
        }
    }

    public class Account_passwordInputSettingsConstructor : account_PasswordInputSettings
    {
        public int flags;
        public byte[] new_salt;
        public byte[] new_password_hash;
        public string hint;
        public string email;

        public Account_passwordInputSettingsConstructor() { }

        public Account_passwordInputSettingsConstructor(int flags, byte[] new_salt, byte[] new_password_hash, string hint, string email)
        {
            this.flags = flags;
            this.new_salt = new_salt;
            this.new_password_hash = new_password_hash;
            this.hint = hint;
            this.email = email;
        }

        public override Constructor Constructor
        { get { return Constructor.account_passwordInputSettings; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xbcfc532c);
            // Calculate flags value
            flags = 0;
            if (new_salt != null) flags += 1;
            if (email != null) flags += 2;

            writer.Write(flags);
            if (new_salt != null)
            {
                Serializers.Bytes.Write(writer, new_salt);
            }
            if (new_password_hash != null)
            {
                Serializers.Bytes.Write(writer, new_password_hash);
            }
            if (hint != null)
            {
                Serializers.String.Write(writer, hint);
            }
            if (email != null)
            {
                Serializers.String.Write(writer, email);
            }
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            if ((flags & 1) != 0)
            {
                new_salt = Serializers.Bytes.Read(reader);
            }
            if ((flags & 1) != 0)
            {
                new_password_hash = Serializers.Bytes.Read(reader);
            }
            if ((flags & 1) != 0)
            {
                hint = Serializers.String.Read(reader);
            }
            if ((flags & 2) != 0)
            {
                email = Serializers.String.Read(reader);
            }
        }

        public override string ToString()
        {
            return string.Format("(account_passwordInputSettings flags:{0} new_salt:{1} new_password_hash:{2} hint:{3} email:{4})", flags, new_salt, new_password_hash, hint, email);
        }
    }

    public class Auth_passwordRecoveryConstructor : auth_PasswordRecovery
    {
        public string email_pattern;

        public Auth_passwordRecoveryConstructor() { }

        public Auth_passwordRecoveryConstructor(string email_pattern)
        {
            this.email_pattern = email_pattern;
        }

        public override Constructor Constructor
        { get { return Constructor.auth_passwordRecovery; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x137948a5);
            Serializers.String.Write(writer, email_pattern);
        }

        public override void Read(BinaryReader reader)
        {
            email_pattern = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(auth_passwordRecovery email_pattern:{0})", email_pattern);
        }
    }

    public class ReceivedNotifyMessageConstructor : ReceivedNotifyMessage
    {
        public int id;
        public int flags;

        public ReceivedNotifyMessageConstructor() { }

        public ReceivedNotifyMessageConstructor(int id, int flags)
        {
            this.id = id;
            this.flags = flags;
        }

        public override Constructor Constructor
        { get { return Constructor.receivedNotifyMessage; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa384b779);
            writer.Write(id);
            writer.Write(flags);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt32();
            flags = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(receivedNotifyMessage id:{0} flags:{1})", id, flags);
        }
    }

    public class ChatInviteEmptyConstructor : ExportedChatInvite
    {
        public ChatInviteEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.chatInviteEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x69df3769);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(chatInviteEmpty)");
        }
    }

    public class ChatInviteExportedConstructor : ExportedChatInvite
    {
        public string link;

        public ChatInviteExportedConstructor() { }

        public ChatInviteExportedConstructor(string link)
        {
            this.link = link;
        }

        public override Constructor Constructor
        { get { return Constructor.chatInviteExported; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xfc2e05bc);
            Serializers.String.Write(writer, link);
        }

        public override void Read(BinaryReader reader)
        {
            link = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(chatInviteExported link:{0})", link);
        }
    }

    public class ChatInviteAlreadyConstructor : ChatInvite
    {
        public Chat chat;

        public ChatInviteAlreadyConstructor() { }

        public ChatInviteAlreadyConstructor(Chat chat)
        {
            this.chat = chat;
        }

        public override Constructor Constructor
        { get { return Constructor.chatInviteAlready; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5a686d7c);
            chat.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            chat = TL.Parse<Chat>(reader);
        }

        public override string ToString()
        {
            return string.Format("(chatInviteAlready chat:{0})", chat);
        }
    }

    public class ChatInviteConstructor : ChatInvite
    {
        public int flags;
        public string title;

        public ChatInviteConstructor() { }

        public ChatInviteConstructor(int flags, string title)
        {
            this.flags = flags;
            this.title = title;
        }

        public override Constructor Constructor
        { get { return Constructor.chatInvite; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x93e99b60);
            // Calculate flags value
            flags = 0;

            writer.Write(flags);
            Serializers.String.Write(writer, title);
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            title = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(chatInvite flags:{0} title:{1})", flags, title);
        }
    }

    public class InputStickerSetEmptyConstructor : InputStickerSet
    {
        public InputStickerSetEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputStickerSetEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xffb62b95);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputStickerSetEmpty)");
        }
    }

    public class InputStickerSetIDConstructor : InputStickerSet
    {
        public long id;
        public long access_hash;

        public InputStickerSetIDConstructor() { }

        public InputStickerSetIDConstructor(long id, long access_hash)
        {
            this.id = id;
            this.access_hash = access_hash;
        }

        public override Constructor Constructor
        { get { return Constructor.inputStickerSetID; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9de7a269);
            writer.Write(id);
            writer.Write(access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            id = reader.ReadInt64();
            access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(inputStickerSetID id:{0} access_hash:{1})", id, access_hash);
        }
    }

    public class InputStickerSetShortNameConstructor : InputStickerSet
    {
        public string short_name;

        public InputStickerSetShortNameConstructor() { }

        public InputStickerSetShortNameConstructor(string short_name)
        {
            this.short_name = short_name;
        }

        public override Constructor Constructor
        { get { return Constructor.inputStickerSetShortName; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x861cc8a0);
            Serializers.String.Write(writer, short_name);
        }

        public override void Read(BinaryReader reader)
        {
            short_name = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(inputStickerSetShortName short_name:{0})", short_name);
        }
    }

    public class StickerSetConstructor : StickerSet
    {
        public int flags;
        public long id;
        public long access_hash;
        public string title;
        public string short_name;
        public int count;
        public int hash;

        public StickerSetConstructor() { }

        public StickerSetConstructor(int flags, long id, long access_hash, string title, string short_name, int count, int hash)
        {
            this.flags = flags;
            this.id = id;
            this.access_hash = access_hash;
            this.title = title;
            this.short_name = short_name;
            this.count = count;
            this.hash = hash;
        }

        public override Constructor Constructor
        { get { return Constructor.stickerSet; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xcd303b41);
            // Calculate flags value
            flags = 0;

            writer.Write(flags);
            writer.Write(id);
            writer.Write(access_hash);
            Serializers.String.Write(writer, title);
            Serializers.String.Write(writer, short_name);
            writer.Write(count);
            writer.Write(hash);
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            id = reader.ReadInt64();
            access_hash = reader.ReadInt64();
            title = Serializers.String.Read(reader);
            short_name = Serializers.String.Read(reader);
            count = reader.ReadInt32();
            hash = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(stickerSet flags:{0} id:{1} access_hash:{2} title:{3} short_name:{4} count:{5} hash:{6})", flags, id, access_hash, title, short_name, count, hash);
        }
    }

    public class Messages_stickerSetConstructor : messages_StickerSet
    {
        public StickerSet set;
        public List<StickerPack> packs;
        public List<Document> documents;

        public Messages_stickerSetConstructor() { }

        public Messages_stickerSetConstructor(StickerSet set, List<StickerPack> packs, List<Document> documents)
        {
            this.set = set;
            this.packs = packs;
            this.documents = documents;
        }

        public override Constructor Constructor
        { get { return Constructor.messages_stickerSet; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb60a24a6);
            set.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(packs.Count);
            foreach (StickerPack packs_element in packs)
                packs_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(documents.Count);
            foreach (Document documents_element in documents)
                documents_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            set = TL.Parse<StickerSet>(reader);
            reader.ReadUInt32(); // vector code
            int packs_count = reader.ReadInt32();
            packs = new List<StickerPack>(packs_count);
            for (int packs_index = 0; packs_index < packs_count; packs_index++)
                packs.Add(TL.Parse<StickerPack>(reader));
            reader.ReadUInt32(); // vector code
            int documents_count = reader.ReadInt32();
            documents = new List<Document>(documents_count);
            for (int documents_index = 0; documents_index < documents_count; documents_index++)
                documents.Add(TL.Parse<Document>(reader));
        }

        public override string ToString()
        {
            return string.Format("(messages_stickerSet set:{0} packs:{1} documents:{2})", set, packs, documents);
        }
    }

    public class BotCommandConstructor : BotCommand
    {
        public string command;
        public string description;

        public BotCommandConstructor() { }

        public BotCommandConstructor(string command, string description)
        {
            this.command = command;
            this.description = description;
        }

        public override Constructor Constructor
        { get { return Constructor.botCommand; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xc27ac8c7);
            Serializers.String.Write(writer, command);
            Serializers.String.Write(writer, description);
        }

        public override void Read(BinaryReader reader)
        {
            command = Serializers.String.Read(reader);
            description = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(botCommand command:{0} description:{1})", command, description);
        }
    }

    public class BotInfoEmptyConstructor : BotInfo
    {
        public BotInfoEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.botInfoEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xbb2e37ce);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(botInfoEmpty)");
        }
    }

    public class BotInfoConstructor : BotInfo
    {
        public int user_id;
        public int version;
        public string share_text;
        public string description;
        public List<BotCommand> commands;

        public BotInfoConstructor() { }

        public BotInfoConstructor(int user_id, int version, string share_text, string description, List<BotCommand> commands)
        {
            this.user_id = user_id;
            this.version = version;
            this.share_text = share_text;
            this.description = description;
            this.commands = commands;
        }

        public override Constructor Constructor
        { get { return Constructor.botInfo; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9cf585d);
            writer.Write(user_id);
            writer.Write(version);
            Serializers.String.Write(writer, share_text);
            Serializers.String.Write(writer, description);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(commands.Count);
            foreach (BotCommand commands_element in commands)
                commands_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            version = reader.ReadInt32();
            share_text = Serializers.String.Read(reader);
            description = Serializers.String.Read(reader);
            reader.ReadUInt32(); // vector code
            int commands_count = reader.ReadInt32();
            commands = new List<BotCommand>(commands_count);
            for (int commands_index = 0; commands_index < commands_count; commands_index++)
                commands.Add(TL.Parse<BotCommand>(reader));
        }

        public override string ToString()
        {
            return string.Format("(botInfo user_id:{0} version:{1} share_text:{2} description:{3} commands:{4})", user_id, version, share_text, description, commands);
        }
    }

    public class KeyboardButtonConstructor : KeyboardButton
    {
        public string text;

        public KeyboardButtonConstructor() { }

        public KeyboardButtonConstructor(string text)
        {
            this.text = text;
        }

        public override Constructor Constructor
        { get { return Constructor.keyboardButton; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa2fa4880);
            Serializers.String.Write(writer, text);
        }

        public override void Read(BinaryReader reader)
        {
            text = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(keyboardButton text:{0})", text);
        }
    }

    public class KeyboardButtonRowConstructor : KeyboardButtonRow
    {
        public List<KeyboardButton> buttons;

        public KeyboardButtonRowConstructor() { }

        public KeyboardButtonRowConstructor(List<KeyboardButton> buttons)
        {
            this.buttons = buttons;
        }

        public override Constructor Constructor
        { get { return Constructor.keyboardButtonRow; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x77608b83);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(buttons.Count);
            foreach (KeyboardButton buttons_element in buttons)
                buttons_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int buttons_count = reader.ReadInt32();
            buttons = new List<KeyboardButton>(buttons_count);
            for (int buttons_index = 0; buttons_index < buttons_count; buttons_index++)
                buttons.Add(TL.Parse<KeyboardButton>(reader));
        }

        public override string ToString()
        {
            return string.Format("(keyboardButtonRow buttons:{0})", buttons);
        }
    }

    public class ReplyKeyboardHideConstructor : ReplyMarkup
    {
        public int flags;

        public ReplyKeyboardHideConstructor() { }

        public ReplyKeyboardHideConstructor(int flags)
        {
            this.flags = flags;
        }

        public override Constructor Constructor
        { get { return Constructor.replyKeyboardHide; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa03e5b85);
            // Calculate flags value
            flags = 0;

            writer.Write(flags);
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(replyKeyboardHide flags:{0})", flags);
        }
    }

    public class ReplyKeyboardForceReplyConstructor : ReplyMarkup
    {
        public int flags;

        public ReplyKeyboardForceReplyConstructor() { }

        public ReplyKeyboardForceReplyConstructor(int flags)
        {
            this.flags = flags;
        }

        public override Constructor Constructor
        { get { return Constructor.replyKeyboardForceReply; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf4108aa0);
            // Calculate flags value
            flags = 0;

            writer.Write(flags);
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(replyKeyboardForceReply flags:{0})", flags);
        }
    }

    public class ReplyKeyboardMarkupConstructor : ReplyMarkup
    {
        public int flags;
        public List<KeyboardButtonRow> rows;

        public ReplyKeyboardMarkupConstructor() { }

        public ReplyKeyboardMarkupConstructor(int flags, List<KeyboardButtonRow> rows)
        {
            this.flags = flags;
            this.rows = rows;
        }

        public override Constructor Constructor
        { get { return Constructor.replyKeyboardMarkup; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x3502758c);
            // Calculate flags value
            flags = 0;

            writer.Write(flags);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(rows.Count);
            foreach (KeyboardButtonRow rows_element in rows)
                rows_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            reader.ReadUInt32(); // vector code
            int rows_count = reader.ReadInt32();
            rows = new List<KeyboardButtonRow>(rows_count);
            for (int rows_index = 0; rows_index < rows_count; rows_index++)
                rows.Add(TL.Parse<KeyboardButtonRow>(reader));
        }

        public override string ToString()
        {
            return string.Format("(replyKeyboardMarkup flags:{0} rows:{1})", flags, rows);
        }
    }

    public class Help_appChangelogEmptyConstructor : help_AppChangelog
    {
        public Help_appChangelogEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.help_appChangelogEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xaf7e0394);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(help_appChangelogEmpty)");
        }
    }

    public class Help_appChangelogConstructor : help_AppChangelog
    {
        public string text;

        public Help_appChangelogConstructor() { }

        public Help_appChangelogConstructor(string text)
        {
            this.text = text;
        }

        public override Constructor Constructor
        { get { return Constructor.help_appChangelog; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x4668e6bd);
            Serializers.String.Write(writer, text);
        }

        public override void Read(BinaryReader reader)
        {
            text = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(help_appChangelog text:{0})", text);
        }
    }

    public class MessageEntityUnknownConstructor : MessageEntity
    {
        public int offset;
        public int length;

        public MessageEntityUnknownConstructor() { }

        public MessageEntityUnknownConstructor(int offset, int length)
        {
            this.offset = offset;
            this.length = length;
        }

        public override Constructor Constructor
        { get { return Constructor.messageEntityUnknown; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xbb92ba95);
            writer.Write(offset);
            writer.Write(length);
        }

        public override void Read(BinaryReader reader)
        {
            offset = reader.ReadInt32();
            length = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messageEntityUnknown offset:{0} length:{1})", offset, length);
        }
    }

    public class MessageEntityMentionConstructor : MessageEntity
    {
        public int offset;
        public int length;

        public MessageEntityMentionConstructor() { }

        public MessageEntityMentionConstructor(int offset, int length)
        {
            this.offset = offset;
            this.length = length;
        }

        public override Constructor Constructor
        { get { return Constructor.messageEntityMention; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xfa04579d);
            writer.Write(offset);
            writer.Write(length);
        }

        public override void Read(BinaryReader reader)
        {
            offset = reader.ReadInt32();
            length = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messageEntityMention offset:{0} length:{1})", offset, length);
        }
    }

    public class MessageEntityHashtagConstructor : MessageEntity
    {
        public int offset;
        public int length;

        public MessageEntityHashtagConstructor() { }

        public MessageEntityHashtagConstructor(int offset, int length)
        {
            this.offset = offset;
            this.length = length;
        }

        public override Constructor Constructor
        { get { return Constructor.messageEntityHashtag; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6f635b0d);
            writer.Write(offset);
            writer.Write(length);
        }

        public override void Read(BinaryReader reader)
        {
            offset = reader.ReadInt32();
            length = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messageEntityHashtag offset:{0} length:{1})", offset, length);
        }
    }

    public class MessageEntityBotCommandConstructor : MessageEntity
    {
        public int offset;
        public int length;

        public MessageEntityBotCommandConstructor() { }

        public MessageEntityBotCommandConstructor(int offset, int length)
        {
            this.offset = offset;
            this.length = length;
        }

        public override Constructor Constructor
        { get { return Constructor.messageEntityBotCommand; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6cef8ac7);
            writer.Write(offset);
            writer.Write(length);
        }

        public override void Read(BinaryReader reader)
        {
            offset = reader.ReadInt32();
            length = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messageEntityBotCommand offset:{0} length:{1})", offset, length);
        }
    }

    public class MessageEntityUrlConstructor : MessageEntity
    {
        public int offset;
        public int length;

        public MessageEntityUrlConstructor() { }

        public MessageEntityUrlConstructor(int offset, int length)
        {
            this.offset = offset;
            this.length = length;
        }

        public override Constructor Constructor
        { get { return Constructor.messageEntityUrl; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x6ed02538);
            writer.Write(offset);
            writer.Write(length);
        }

        public override void Read(BinaryReader reader)
        {
            offset = reader.ReadInt32();
            length = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messageEntityUrl offset:{0} length:{1})", offset, length);
        }
    }

    public class MessageEntityEmailConstructor : MessageEntity
    {
        public int offset;
        public int length;

        public MessageEntityEmailConstructor() { }

        public MessageEntityEmailConstructor(int offset, int length)
        {
            this.offset = offset;
            this.length = length;
        }

        public override Constructor Constructor
        { get { return Constructor.messageEntityEmail; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x64e475c2);
            writer.Write(offset);
            writer.Write(length);
        }

        public override void Read(BinaryReader reader)
        {
            offset = reader.ReadInt32();
            length = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messageEntityEmail offset:{0} length:{1})", offset, length);
        }
    }

    public class MessageEntityBoldConstructor : MessageEntity
    {
        public int offset;
        public int length;

        public MessageEntityBoldConstructor() { }

        public MessageEntityBoldConstructor(int offset, int length)
        {
            this.offset = offset;
            this.length = length;
        }

        public override Constructor Constructor
        { get { return Constructor.messageEntityBold; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xbd610bc9);
            writer.Write(offset);
            writer.Write(length);
        }

        public override void Read(BinaryReader reader)
        {
            offset = reader.ReadInt32();
            length = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messageEntityBold offset:{0} length:{1})", offset, length);
        }
    }

    public class MessageEntityItalicConstructor : MessageEntity
    {
        public int offset;
        public int length;

        public MessageEntityItalicConstructor() { }

        public MessageEntityItalicConstructor(int offset, int length)
        {
            this.offset = offset;
            this.length = length;
        }

        public override Constructor Constructor
        { get { return Constructor.messageEntityItalic; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x826f8b60);
            writer.Write(offset);
            writer.Write(length);
        }

        public override void Read(BinaryReader reader)
        {
            offset = reader.ReadInt32();
            length = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messageEntityItalic offset:{0} length:{1})", offset, length);
        }
    }

    public class MessageEntityCodeConstructor : MessageEntity
    {
        public int offset;
        public int length;

        public MessageEntityCodeConstructor() { }

        public MessageEntityCodeConstructor(int offset, int length)
        {
            this.offset = offset;
            this.length = length;
        }

        public override Constructor Constructor
        { get { return Constructor.messageEntityCode; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x28a20571);
            writer.Write(offset);
            writer.Write(length);
        }

        public override void Read(BinaryReader reader)
        {
            offset = reader.ReadInt32();
            length = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messageEntityCode offset:{0} length:{1})", offset, length);
        }
    }

    public class MessageEntityPreConstructor : MessageEntity
    {
        public int offset;
        public int length;
        public string language;

        public MessageEntityPreConstructor() { }

        public MessageEntityPreConstructor(int offset, int length, string language)
        {
            this.offset = offset;
            this.length = length;
            this.language = language;
        }

        public override Constructor Constructor
        { get { return Constructor.messageEntityPre; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x73924be0);
            writer.Write(offset);
            writer.Write(length);
            Serializers.String.Write(writer, language);
        }

        public override void Read(BinaryReader reader)
        {
            offset = reader.ReadInt32();
            length = reader.ReadInt32();
            language = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(messageEntityPre offset:{0} length:{1} language:{2})", offset, length, language);
        }
    }

    public class MessageEntityTextUrlConstructor : MessageEntity
    {
        public int offset;
        public int length;
        public string url;

        public MessageEntityTextUrlConstructor() { }

        public MessageEntityTextUrlConstructor(int offset, int length, string url)
        {
            this.offset = offset;
            this.length = length;
            this.url = url;
        }

        public override Constructor Constructor
        { get { return Constructor.messageEntityTextUrl; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x76a6d327);
            writer.Write(offset);
            writer.Write(length);
            Serializers.String.Write(writer, url);
        }

        public override void Read(BinaryReader reader)
        {
            offset = reader.ReadInt32();
            length = reader.ReadInt32();
            url = Serializers.String.Read(reader);
        }

        public override string ToString()
        {
            return string.Format("(messageEntityTextUrl offset:{0} length:{1} url:{2})", offset, length, url);
        }
    }

    public class InputChannelEmptyConstructor : InputChannel
    {
        public InputChannelEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.inputChannelEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xee8c1e86);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(inputChannelEmpty)");
        }
    }

    public class InputChannelConstructor : InputChannel
    {
        public int channel_id;
        public long access_hash;

        public InputChannelConstructor() { }

        public InputChannelConstructor(int channel_id, long access_hash)
        {
            this.channel_id = channel_id;
            this.access_hash = access_hash;
        }

        public override Constructor Constructor
        { get { return Constructor.inputChannel; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xafeb712e);
            writer.Write(channel_id);
            writer.Write(access_hash);
        }

        public override void Read(BinaryReader reader)
        {
            channel_id = reader.ReadInt32();
            access_hash = reader.ReadInt64();
        }

        public override string ToString()
        {
            return string.Format("(inputChannel channel_id:{0} access_hash:{1})", channel_id, access_hash);
        }
    }

    public class Contacts_resolvedPeerConstructor : contacts_ResolvedPeer
    {
        public Peer peer;
        public List<Chat> chats;
        public List<User> users;

        public Contacts_resolvedPeerConstructor() { }

        public Contacts_resolvedPeerConstructor(Peer peer, List<Chat> chats, List<User> users)
        {
            this.peer = peer;
            this.chats = chats;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.contacts_resolvedPeer; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x7f077ad9);
            peer.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(chats.Count);
            foreach (Chat chats_element in chats)
                chats_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            peer = TL.Parse<Peer>(reader);
            reader.ReadUInt32(); // vector code
            int chats_count = reader.ReadInt32();
            chats = new List<Chat>(chats_count);
            for (int chats_index = 0; chats_index < chats_count; chats_index++)
                chats.Add(TL.Parse<Chat>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(contacts_resolvedPeer peer:{0} chats:{1} users:{2})", peer, chats, users);
        }
    }

    public class MessageRangeConstructor : MessageRange
    {
        public int min_id;
        public int max_id;

        public MessageRangeConstructor() { }

        public MessageRangeConstructor(int min_id, int max_id)
        {
            this.min_id = min_id;
            this.max_id = max_id;
        }

        public override Constructor Constructor
        { get { return Constructor.messageRange; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xae30253);
            writer.Write(min_id);
            writer.Write(max_id);
        }

        public override void Read(BinaryReader reader)
        {
            min_id = reader.ReadInt32();
            max_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messageRange min_id:{0} max_id:{1})", min_id, max_id);
        }
    }

    public class MessageGroupConstructor : MessageGroup
    {
        public int min_id;
        public int max_id;
        public int count;
        public int date;

        public MessageGroupConstructor() { }

        public MessageGroupConstructor(int min_id, int max_id, int count, int date)
        {
            this.min_id = min_id;
            this.max_id = max_id;
            this.count = count;
            this.date = date;
        }

        public override Constructor Constructor
        { get { return Constructor.messageGroup; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe8346f53);
            writer.Write(min_id);
            writer.Write(max_id);
            writer.Write(count);
            writer.Write(date);
        }

        public override void Read(BinaryReader reader)
        {
            min_id = reader.ReadInt32();
            max_id = reader.ReadInt32();
            count = reader.ReadInt32();
            date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(messageGroup min_id:{0} max_id:{1} count:{2} date:{3})", min_id, max_id, count, date);
        }
    }

    public class Updates_channelDifferenceEmptyConstructor : updates_ChannelDifference
    {
        public int flags;
        public int pts;
        public int? timeout;

        public Updates_channelDifferenceEmptyConstructor() { }

        public Updates_channelDifferenceEmptyConstructor(int flags, int pts, int? timeout)
        {
            this.flags = flags;
            this.pts = pts;
            this.timeout = timeout;
        }

        public override Constructor Constructor
        { get { return Constructor.updates_channelDifferenceEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x3e11affb);
            // Calculate flags value
            flags = 0;
            if (timeout != null) flags += 2;

            writer.Write(flags);
            writer.Write(pts);
            if (timeout != null)
            {
                writer.Write(timeout.Value);
            }
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            pts = reader.ReadInt32();
            if ((flags & 2) != 0)
            {
                timeout = reader.ReadInt32();
            }
        }

        public override string ToString()
        {
            return string.Format("(updates_channelDifferenceEmpty flags:{0} pts:{1} timeout:{2})", flags, pts, timeout);
        }
    }

    public class Updates_channelDifferenceTooLongConstructor : updates_ChannelDifference
    {
        public int flags;
        public int pts;
        public int? timeout;
        public int top_message;
        public int top_important_message;
        public int read_inbox_max_id;
        public int unread_count;
        public int unread_important_count;
        public List<Message> messages;
        public List<Chat> chats;
        public List<User> users;

        public Updates_channelDifferenceTooLongConstructor() { }

        public Updates_channelDifferenceTooLongConstructor(int flags, int pts, int? timeout, int top_message, int top_important_message, int read_inbox_max_id, int unread_count, int unread_important_count, List<Message> messages, List<Chat> chats, List<User> users)
        {
            this.flags = flags;
            this.pts = pts;
            this.timeout = timeout;
            this.top_message = top_message;
            this.top_important_message = top_important_message;
            this.read_inbox_max_id = read_inbox_max_id;
            this.unread_count = unread_count;
            this.unread_important_count = unread_important_count;
            this.messages = messages;
            this.chats = chats;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.updates_channelDifferenceTooLong; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x5e167646);
            // Calculate flags value
            flags = 0;
            if (timeout != null) flags += 2;

            writer.Write(flags);
            writer.Write(pts);
            if (timeout != null)
            {
                writer.Write(timeout.Value);
            }
            writer.Write(top_message);
            writer.Write(top_important_message);
            writer.Write(read_inbox_max_id);
            writer.Write(unread_count);
            writer.Write(unread_important_count);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(messages.Count);
            foreach (Message messages_element in messages)
                messages_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(chats.Count);
            foreach (Chat chats_element in chats)
                chats_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            pts = reader.ReadInt32();
            if ((flags & 2) != 0)
            {
                timeout = reader.ReadInt32();
            }
            top_message = reader.ReadInt32();
            top_important_message = reader.ReadInt32();
            read_inbox_max_id = reader.ReadInt32();
            unread_count = reader.ReadInt32();
            unread_important_count = reader.ReadInt32();
            reader.ReadUInt32(); // vector code
            int messages_count = reader.ReadInt32();
            messages = new List<Message>(messages_count);
            for (int messages_index = 0; messages_index < messages_count; messages_index++)
                messages.Add(TL.Parse<Message>(reader));
            reader.ReadUInt32(); // vector code
            int chats_count = reader.ReadInt32();
            chats = new List<Chat>(chats_count);
            for (int chats_index = 0; chats_index < chats_count; chats_index++)
                chats.Add(TL.Parse<Chat>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(updates_channelDifferenceTooLong flags:{0} pts:{1} timeout:{2} top_message:{3} top_important_message:{4} read_inbox_max_id:{5} unread_count:{6} unread_important_count:{7} messages:{8} chats:{9} users:{10})", flags, pts, timeout, top_message, top_important_message, read_inbox_max_id, unread_count, unread_important_count, messages, chats, users);
        }
    }

    public class Updates_channelDifferenceConstructor : updates_ChannelDifference
    {
        public int flags;
        public int pts;
        public int? timeout;
        public List<Message> new_messages;
        public List<Update> other_updates;
        public List<Chat> chats;
        public List<User> users;

        public Updates_channelDifferenceConstructor() { }

        public Updates_channelDifferenceConstructor(int flags, int pts, int? timeout, List<Message> new_messages, List<Update> other_updates, List<Chat> chats, List<User> users)
        {
            this.flags = flags;
            this.pts = pts;
            this.timeout = timeout;
            this.new_messages = new_messages;
            this.other_updates = other_updates;
            this.chats = chats;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.updates_channelDifference; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x2064674e);
            // Calculate flags value
            flags = 0;
            if (timeout != null) flags += 2;

            writer.Write(flags);
            writer.Write(pts);
            if (timeout != null)
            {
                writer.Write(timeout.Value);
            }
            writer.Write(0x1cb5c415); // vector code
            writer.Write(new_messages.Count);
            foreach (Message new_messages_element in new_messages)
                new_messages_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(other_updates.Count);
            foreach (Update other_updates_element in other_updates)
                other_updates_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(chats.Count);
            foreach (Chat chats_element in chats)
                chats_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            pts = reader.ReadInt32();
            if ((flags & 2) != 0)
            {
                timeout = reader.ReadInt32();
            }
            reader.ReadUInt32(); // vector code
            int new_messages_count = reader.ReadInt32();
            new_messages = new List<Message>(new_messages_count);
            for (int new_messages_index = 0; new_messages_index < new_messages_count; new_messages_index++)
                new_messages.Add(TL.Parse<Message>(reader));
            reader.ReadUInt32(); // vector code
            int other_updates_count = reader.ReadInt32();
            other_updates = new List<Update>(other_updates_count);
            for (int other_updates_index = 0; other_updates_index < other_updates_count; other_updates_index++)
                other_updates.Add(TL.Parse<Update>(reader));
            reader.ReadUInt32(); // vector code
            int chats_count = reader.ReadInt32();
            chats = new List<Chat>(chats_count);
            for (int chats_index = 0; chats_index < chats_count; chats_index++)
                chats.Add(TL.Parse<Chat>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(updates_channelDifference flags:{0} pts:{1} timeout:{2} new_messages:{3} other_updates:{4} chats:{5} users:{6})", flags, pts, timeout, new_messages, other_updates, chats, users);
        }
    }

    public class ChannelMessagesFilterEmptyConstructor : ChannelMessagesFilter
    {
        public ChannelMessagesFilterEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.channelMessagesFilterEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x94d42ee7);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(channelMessagesFilterEmpty)");
        }
    }

    public class ChannelMessagesFilterConstructor : ChannelMessagesFilter
    {
        public int flags;
        public List<MessageRange> ranges;

        public ChannelMessagesFilterConstructor() { }

        public ChannelMessagesFilterConstructor(int flags, List<MessageRange> ranges)
        {
            this.flags = flags;
            this.ranges = ranges;
        }

        public override Constructor Constructor
        { get { return Constructor.channelMessagesFilter; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xcd77d957);
            // Calculate flags value
            flags = 0;

            writer.Write(flags);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(ranges.Count);
            foreach (MessageRange ranges_element in ranges)
                ranges_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            flags = reader.ReadInt32();
            reader.ReadUInt32(); // vector code
            int ranges_count = reader.ReadInt32();
            ranges = new List<MessageRange>(ranges_count);
            for (int ranges_index = 0; ranges_index < ranges_count; ranges_index++)
                ranges.Add(TL.Parse<MessageRange>(reader));
        }

        public override string ToString()
        {
            return string.Format("(channelMessagesFilter flags:{0} ranges:{1})", flags, ranges);
        }
    }

    public class ChannelMessagesFilterCollapsedConstructor : ChannelMessagesFilter
    {
        public ChannelMessagesFilterCollapsedConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.channelMessagesFilterCollapsed; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xfa01232e);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(channelMessagesFilterCollapsed)");
        }
    }

    public class ChannelParticipantConstructor : ChannelParticipant
    {
        public int user_id;
        public int date;

        public ChannelParticipantConstructor() { }

        public ChannelParticipantConstructor(int user_id, int date)
        {
            this.user_id = user_id;
            this.date = date;
        }

        public override Constructor Constructor
        { get { return Constructor.channelParticipant; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x15ebac1d);
            writer.Write(user_id);
            writer.Write(date);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(channelParticipant user_id:{0} date:{1})", user_id, date);
        }
    }

    public class ChannelParticipantSelfConstructor : ChannelParticipant
    {
        public int user_id;
        public int inviter_id;
        public int date;

        public ChannelParticipantSelfConstructor() { }

        public ChannelParticipantSelfConstructor(int user_id, int inviter_id, int date)
        {
            this.user_id = user_id;
            this.inviter_id = inviter_id;
            this.date = date;
        }

        public override Constructor Constructor
        { get { return Constructor.channelParticipantSelf; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xa3289a6d);
            writer.Write(user_id);
            writer.Write(inviter_id);
            writer.Write(date);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            inviter_id = reader.ReadInt32();
            date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(channelParticipantSelf user_id:{0} inviter_id:{1} date:{2})", user_id, inviter_id, date);
        }
    }

    public class ChannelParticipantModeratorConstructor : ChannelParticipant
    {
        public int user_id;
        public int inviter_id;
        public int date;

        public ChannelParticipantModeratorConstructor() { }

        public ChannelParticipantModeratorConstructor(int user_id, int inviter_id, int date)
        {
            this.user_id = user_id;
            this.inviter_id = inviter_id;
            this.date = date;
        }

        public override Constructor Constructor
        { get { return Constructor.channelParticipantModerator; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x91057fef);
            writer.Write(user_id);
            writer.Write(inviter_id);
            writer.Write(date);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            inviter_id = reader.ReadInt32();
            date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(channelParticipantModerator user_id:{0} inviter_id:{1} date:{2})", user_id, inviter_id, date);
        }
    }

    public class ChannelParticipantEditorConstructor : ChannelParticipant
    {
        public int user_id;
        public int inviter_id;
        public int date;

        public ChannelParticipantEditorConstructor() { }

        public ChannelParticipantEditorConstructor(int user_id, int inviter_id, int date)
        {
            this.user_id = user_id;
            this.inviter_id = inviter_id;
            this.date = date;
        }

        public override Constructor Constructor
        { get { return Constructor.channelParticipantEditor; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x98192d61);
            writer.Write(user_id);
            writer.Write(inviter_id);
            writer.Write(date);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            inviter_id = reader.ReadInt32();
            date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(channelParticipantEditor user_id:{0} inviter_id:{1} date:{2})", user_id, inviter_id, date);
        }
    }

    public class ChannelParticipantKickedConstructor : ChannelParticipant
    {
        public int user_id;
        public int kicked_by;
        public int date;

        public ChannelParticipantKickedConstructor() { }

        public ChannelParticipantKickedConstructor(int user_id, int kicked_by, int date)
        {
            this.user_id = user_id;
            this.kicked_by = kicked_by;
            this.date = date;
        }

        public override Constructor Constructor
        { get { return Constructor.channelParticipantKicked; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x8cc5e69a);
            writer.Write(user_id);
            writer.Write(kicked_by);
            writer.Write(date);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
            kicked_by = reader.ReadInt32();
            date = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(channelParticipantKicked user_id:{0} kicked_by:{1} date:{2})", user_id, kicked_by, date);
        }
    }

    public class ChannelParticipantCreatorConstructor : ChannelParticipant
    {
        public int user_id;

        public ChannelParticipantCreatorConstructor() { }

        public ChannelParticipantCreatorConstructor(int user_id)
        {
            this.user_id = user_id;
        }

        public override Constructor Constructor
        { get { return Constructor.channelParticipantCreator; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xe3e2e1f9);
            writer.Write(user_id);
        }

        public override void Read(BinaryReader reader)
        {
            user_id = reader.ReadInt32();
        }

        public override string ToString()
        {
            return string.Format("(channelParticipantCreator user_id:{0})", user_id);
        }
    }

    public class ChannelParticipantsRecentConstructor : ChannelParticipantsFilter
    {
        public ChannelParticipantsRecentConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.channelParticipantsRecent; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xde3f3c79);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(channelParticipantsRecent)");
        }
    }

    public class ChannelParticipantsAdminsConstructor : ChannelParticipantsFilter
    {
        public ChannelParticipantsAdminsConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.channelParticipantsAdmins; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb4608969);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(channelParticipantsAdmins)");
        }
    }

    public class ChannelParticipantsKickedConstructor : ChannelParticipantsFilter
    {
        public ChannelParticipantsKickedConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.channelParticipantsKicked; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x3c37bb7a);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(channelParticipantsKicked)");
        }
    }

    public class ChannelRoleEmptyConstructor : ChannelParticipantRole
    {
        public ChannelRoleEmptyConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.channelRoleEmpty; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xb285a0c6);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(channelRoleEmpty)");
        }
    }

    public class ChannelRoleModeratorConstructor : ChannelParticipantRole
    {
        public ChannelRoleModeratorConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.channelRoleModerator; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x9618d975);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(channelRoleModerator)");
        }
    }

    public class ChannelRoleEditorConstructor : ChannelParticipantRole
    {
        public ChannelRoleEditorConstructor()
        {
        }

        public override Constructor Constructor
        { get { return Constructor.channelRoleEditor; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0x820bfe8c);
        }

        public override void Read(BinaryReader reader)
        {
        }

        public override string ToString()
        {
            return string.Format("(channelRoleEditor)");
        }
    }

    public class Channels_channelParticipantsConstructor : channels_ChannelParticipants
    {
        public int count;
        public List<ChannelParticipant> participants;
        public List<User> users;

        public Channels_channelParticipantsConstructor() { }

        public Channels_channelParticipantsConstructor(int count, List<ChannelParticipant> participants, List<User> users)
        {
            this.count = count;
            this.participants = participants;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.channels_channelParticipants; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xf56ee2a8);
            writer.Write(count);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(participants.Count);
            foreach (ChannelParticipant participants_element in participants)
                participants_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            count = reader.ReadInt32();
            reader.ReadUInt32(); // vector code
            int participants_count = reader.ReadInt32();
            participants = new List<ChannelParticipant>(participants_count);
            for (int participants_index = 0; participants_index < participants_count; participants_index++)
                participants.Add(TL.Parse<ChannelParticipant>(reader));
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(channels_channelParticipants count:{0} participants:{1} users:{2})", count, participants, users);
        }
    }

    public class Channels_channelParticipantConstructor : channels_ChannelParticipant
    {
        public ChannelParticipant participant;
        public List<User> users;

        public Channels_channelParticipantConstructor() { }

        public Channels_channelParticipantConstructor(ChannelParticipant participant, List<User> users)
        {
            this.participant = participant;
            this.users = users;
        }

        public override Constructor Constructor
        { get { return Constructor.channels_channelParticipant; } }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(0xd0d9b163);
            participant.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(users.Count);
            foreach (User users_element in users)
                users_element.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            participant = TL.Parse<ChannelParticipant>(reader);
            reader.ReadUInt32(); // vector code
            int users_count = reader.ReadInt32();
            users = new List<User>(users_count);
            for (int users_index = 0; users_index < users_count; users_index++)
                users.Add(TL.Parse<User>(reader));
        }

        public override string ToString()
        {
            return string.Format("(channels_channelParticipant participant:{0} users:{1})", participant, users);
        }
    }


    // Requests
    public class Rpc_drop_answerRequest : MTProtoRequest
    {
        long _req_msg_id;

        public RpcDropAnswer result;

        public Rpc_drop_answerRequest(long req_msg_id)
        {
            _req_msg_id = req_msg_id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x58e4a740);
            writer.Write(_req_msg_id);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<RpcDropAnswer>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class PingRequest : MTProtoRequest
    {
        long _ping_id;

        public Pong result;

        public PingRequest(long ping_id)
        {
            _ping_id = ping_id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x7abe77ec);
            writer.Write(_ping_id);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Pong>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Ping_delay_disconnectRequest : MTProtoRequest
    {
        long _ping_id;
        int _disconnect_delay;

        public Pong result;

        public Ping_delay_disconnectRequest(long ping_id, int disconnect_delay)
        {
            _ping_id = ping_id;
            _disconnect_delay = disconnect_delay;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xf3427b8c);
            writer.Write(_ping_id);
            writer.Write(_disconnect_delay);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Pong>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Destroy_sessionRequest : MTProtoRequest
    {
        long _session_id;

        public DestroySessionRes result;

        public Destroy_sessionRequest(long session_id)
        {
            _session_id = session_id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xe7512126);
            writer.Write(_session_id);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<DestroySessionRes>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Register_SaveDeveloperInfoRequest : MTProtoRequest
    {
        string _name;
        string _email;
        string _phone_number;
        int _age;
        string _city;

        public bool result;

        public Register_SaveDeveloperInfoRequest(string name, string email, string phone_number, int age, string city)
        {
            _name = name;
            _email = email;
            _phone_number = phone_number;
            _age = age;
            _city = city;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x9a5f6e95);
            Serializers.String.Write(writer, _name);
            Serializers.String.Write(writer, _email);
            Serializers.String.Write(writer, _phone_number);
            writer.Write(_age);
            Serializers.String.Write(writer, _city);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Auth_CheckPhoneRequest : MTProtoRequest
    {
        string _phone_number;

        public auth_CheckedPhone result;

        public Auth_CheckPhoneRequest(string phone_number)
        {
            _phone_number = phone_number;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x6fe51dfb);
            Serializers.String.Write(writer, _phone_number);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<auth_CheckedPhone>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Auth_SendCodeRequest : MTProtoRequest
    {
        string _phone_number;
        int _sms_type;
        int _api_id;
        string _api_hash;
        string _lang_code;

        public auth_SentCode result;

        public Auth_SendCodeRequest(string phone_number, int sms_type, int api_id, string api_hash, string lang_code)
        {
            _phone_number = phone_number;
            _sms_type = sms_type;
            _api_id = api_id;
            _api_hash = api_hash;
            _lang_code = lang_code;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x768d5f4d);
            Serializers.String.Write(writer, _phone_number);
            writer.Write(_sms_type);
            writer.Write(_api_id);
            Serializers.String.Write(writer, _api_hash);
            Serializers.String.Write(writer, _lang_code);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<auth_SentCode>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Auth_SendCallRequest : MTProtoRequest
    {
        string _phone_number;
        string _phone_code_hash;

        public bool result;

        public Auth_SendCallRequest(string phone_number, string phone_code_hash)
        {
            _phone_number = phone_number;
            _phone_code_hash = phone_code_hash;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x3c51564);
            Serializers.String.Write(writer, _phone_number);
            Serializers.String.Write(writer, _phone_code_hash);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Auth_SignUpRequest : MTProtoRequest
    {
        string _phone_number;
        string _phone_code_hash;
        string _phone_code;
        string _first_name;
        string _last_name;

        public auth_Authorization result;

        public Auth_SignUpRequest(string phone_number, string phone_code_hash, string phone_code, string first_name, string last_name)
        {
            _phone_number = phone_number;
            _phone_code_hash = phone_code_hash;
            _phone_code = phone_code;
            _first_name = first_name;
            _last_name = last_name;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x1b067634);
            Serializers.String.Write(writer, _phone_number);
            Serializers.String.Write(writer, _phone_code_hash);
            Serializers.String.Write(writer, _phone_code);
            Serializers.String.Write(writer, _first_name);
            Serializers.String.Write(writer, _last_name);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<auth_Authorization>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Auth_SignInRequest : MTProtoRequest
    {
        string _phone_number;
        string _phone_code_hash;
        string _phone_code;

        public auth_Authorization result;

        public Auth_SignInRequest(string phone_number, string phone_code_hash, string phone_code)
        {
            _phone_number = phone_number;
            _phone_code_hash = phone_code_hash;
            _phone_code = phone_code;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xbcd51581);
            Serializers.String.Write(writer, _phone_number);
            Serializers.String.Write(writer, _phone_code_hash);
            Serializers.String.Write(writer, _phone_code);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<auth_Authorization>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Auth_LogOutRequest : MTProtoRequest
    {
        public bool result;

        public Auth_LogOutRequest()
        {
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x5717da40);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Auth_ResetAuthorizationsRequest : MTProtoRequest
    {
        public bool result;

        public Auth_ResetAuthorizationsRequest()
        {
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x9fab0d1a);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Auth_SendInvitesRequest : MTProtoRequest
    {
        List<string> _phone_numbers;
        string _message;

        public bool result;

        public Auth_SendInvitesRequest(List<string> phone_numbers, string message)
        {
            _phone_numbers = phone_numbers;
            _message = message;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x771c1d97);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_phone_numbers.Count);
            foreach (string phone_numbers_element in _phone_numbers)
                Serializers.String.Write(writer, phone_numbers_element);
            Serializers.String.Write(writer, _message);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Auth_ExportAuthorizationRequest : MTProtoRequest
    {
        int _dc_id;

        public auth_ExportedAuthorization result;

        public Auth_ExportAuthorizationRequest(int dc_id)
        {
            _dc_id = dc_id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xe5bfffcd);
            writer.Write(_dc_id);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<auth_ExportedAuthorization>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Auth_ImportAuthorizationRequest : MTProtoRequest
    {
        int _id;
        byte[] _bytes;

        public auth_Authorization result;

        public Auth_ImportAuthorizationRequest(int id, byte[] bytes)
        {
            _id = id;
            _bytes = bytes;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xe3ef9613);
            writer.Write(_id);
            Serializers.Bytes.Write(writer, _bytes);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<auth_Authorization>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Auth_BindTempAuthKeyRequest : MTProtoRequest
    {
        long _perm_auth_key_id;
        long _nonce;
        int _expires_at;
        byte[] _encrypted_message;

        public bool result;

        public Auth_BindTempAuthKeyRequest(long perm_auth_key_id, long nonce, int expires_at, byte[] encrypted_message)
        {
            _perm_auth_key_id = perm_auth_key_id;
            _nonce = nonce;
            _expires_at = expires_at;
            _encrypted_message = encrypted_message;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xcdd42a05);
            writer.Write(_perm_auth_key_id);
            writer.Write(_nonce);
            writer.Write(_expires_at);
            Serializers.Bytes.Write(writer, _encrypted_message);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Auth_SendSmsRequest : MTProtoRequest
    {
        string _phone_number;
        string _phone_code_hash;

        public bool result;

        public Auth_SendSmsRequest(string phone_number, string phone_code_hash)
        {
            _phone_number = phone_number;
            _phone_code_hash = phone_code_hash;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xda9f3e8);
            Serializers.String.Write(writer, _phone_number);
            Serializers.String.Write(writer, _phone_code_hash);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Auth_ImportBotAuthorizationRequest : MTProtoRequest
    {
        int _flags;
        int _api_id;
        string _api_hash;
        string _bot_auth_token;

        public auth_Authorization result;

        public Auth_ImportBotAuthorizationRequest(int flags, int api_id, string api_hash, string bot_auth_token)
        {
            _flags = flags;
            _api_id = api_id;
            _api_hash = api_hash;
            _bot_auth_token = bot_auth_token;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x67a3ff2c);
            writer.Write(_flags);
            writer.Write(_api_id);
            Serializers.String.Write(writer, _api_hash);
            Serializers.String.Write(writer, _bot_auth_token);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<auth_Authorization>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Auth_CheckPasswordRequest : MTProtoRequest
    {
        byte[] _password_hash;

        public auth_Authorization result;

        public Auth_CheckPasswordRequest(byte[] password_hash)
        {
            _password_hash = password_hash;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xa63011e);
            Serializers.Bytes.Write(writer, _password_hash);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<auth_Authorization>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Auth_RequestPasswordRecoveryRequest : MTProtoRequest
    {
        public auth_PasswordRecovery result;

        public Auth_RequestPasswordRecoveryRequest()
        {
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xd897bc66);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<auth_PasswordRecovery>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Auth_RecoverPasswordRequest : MTProtoRequest
    {
        string _code;

        public auth_Authorization result;

        public Auth_RecoverPasswordRequest(string code)
        {
            _code = code;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x4ea56e92);
            Serializers.String.Write(writer, _code);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<auth_Authorization>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_RegisterDeviceRequest : MTProtoRequest
    {
        int _token_type;
        string _token;
        string _device_model;
        string _system_version;
        string _app_version;
        bool _app_sandbox;
        string _lang_code;

        public bool result;

        public Account_RegisterDeviceRequest(int token_type, string token, string device_model, string system_version, string app_version, bool app_sandbox, string lang_code)
        {
            _token_type = token_type;
            _token = token;
            _device_model = device_model;
            _system_version = system_version;
            _app_version = app_version;
            _app_sandbox = app_sandbox;
            _lang_code = lang_code;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x446c712c);
            writer.Write(_token_type);
            Serializers.String.Write(writer, _token);
            Serializers.String.Write(writer, _device_model);
            Serializers.String.Write(writer, _system_version);
            Serializers.String.Write(writer, _app_version);
            writer.Write(_app_sandbox ? 0x997275b5 : 0xbc799737);
            Serializers.String.Write(writer, _lang_code);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_UnregisterDeviceRequest : MTProtoRequest
    {
        int _token_type;
        string _token;

        public bool result;

        public Account_UnregisterDeviceRequest(int token_type, string token)
        {
            _token_type = token_type;
            _token = token;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x65c55b40);
            writer.Write(_token_type);
            Serializers.String.Write(writer, _token);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_UpdateNotifySettingsRequest : MTProtoRequest
    {
        InputNotifyPeer _peer;
        InputPeerNotifySettings _settings;

        public bool result;

        public Account_UpdateNotifySettingsRequest(InputNotifyPeer peer, InputPeerNotifySettings settings)
        {
            _peer = peer;
            _settings = settings;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x84be5b93);
            _peer.Write(writer);
            _settings.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_GetNotifySettingsRequest : MTProtoRequest
    {
        InputNotifyPeer _peer;

        public PeerNotifySettings result;

        public Account_GetNotifySettingsRequest(InputNotifyPeer peer)
        {
            _peer = peer;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x12b3ad31);
            _peer.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<PeerNotifySettings>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_ResetNotifySettingsRequest : MTProtoRequest
    {
        public bool result;

        public Account_ResetNotifySettingsRequest()
        {
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xdb7e1747);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_UpdateProfileRequest : MTProtoRequest
    {
        string _first_name;
        string _last_name;

        public User result;

        public Account_UpdateProfileRequest(string first_name, string last_name)
        {
            _first_name = first_name;
            _last_name = last_name;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xf0888d68);
            Serializers.String.Write(writer, _first_name);
            Serializers.String.Write(writer, _last_name);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<User>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_UpdateStatusRequest : MTProtoRequest
    {
        bool _offline;

        public bool result;

        public Account_UpdateStatusRequest(bool offline)
        {
            _offline = offline;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x6628562c);
            writer.Write(_offline ? 0x997275b5 : 0xbc799737);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_GetWallPapersRequest : MTProtoRequest
    {
        public List<WallPaper> result;

        public Account_GetWallPapersRequest()
        {
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xc04cfac2);
        }

        public override void OnResponse(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int result_count = reader.ReadInt32();
            result = new List<WallPaper>(result_count);
            for (int result_index = 0; result_index < result_count; result_index++)
                result.Add(TL.Parse<WallPaper>(reader));
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_CheckUsernameRequest : MTProtoRequest
    {
        string _username;

        public bool result;

        public Account_CheckUsernameRequest(string username)
        {
            _username = username;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x2714d86c);
            Serializers.String.Write(writer, _username);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_UpdateUsernameRequest : MTProtoRequest
    {
        string _username;

        public User result;

        public Account_UpdateUsernameRequest(string username)
        {
            _username = username;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x3e0bdd7c);
            Serializers.String.Write(writer, _username);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<User>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_GetPrivacyRequest : MTProtoRequest
    {
        InputPrivacyKey _key;

        public account_PrivacyRules result;

        public Account_GetPrivacyRequest(InputPrivacyKey key)
        {
            _key = key;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xdadbc950);
            _key.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<account_PrivacyRules>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_SetPrivacyRequest : MTProtoRequest
    {
        InputPrivacyKey _key;
        List<InputPrivacyRule> _rules;

        public account_PrivacyRules result;

        public Account_SetPrivacyRequest(InputPrivacyKey key, List<InputPrivacyRule> rules)
        {
            _key = key;
            _rules = rules;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xc9f81ce8);
            _key.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_rules.Count);
            foreach (InputPrivacyRule rules_element in _rules)
                rules_element.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<account_PrivacyRules>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_DeleteAccountRequest : MTProtoRequest
    {
        string _reason;

        public bool result;

        public Account_DeleteAccountRequest(string reason)
        {
            _reason = reason;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x418d4e0b);
            Serializers.String.Write(writer, _reason);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_GetAccountTTLRequest : MTProtoRequest
    {
        public AccountDaysTTL result;

        public Account_GetAccountTTLRequest()
        {
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x8fc711d);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<AccountDaysTTL>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_SetAccountTTLRequest : MTProtoRequest
    {
        AccountDaysTTL _ttl;

        public bool result;

        public Account_SetAccountTTLRequest(AccountDaysTTL ttl)
        {
            _ttl = ttl;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x2442485e);
            _ttl.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_SendChangePhoneCodeRequest : MTProtoRequest
    {
        string _phone_number;

        public account_SentChangePhoneCode result;

        public Account_SendChangePhoneCodeRequest(string phone_number)
        {
            _phone_number = phone_number;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xa407a8f4);
            Serializers.String.Write(writer, _phone_number);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<account_SentChangePhoneCode>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_ChangePhoneRequest : MTProtoRequest
    {
        string _phone_number;
        string _phone_code_hash;
        string _phone_code;

        public User result;

        public Account_ChangePhoneRequest(string phone_number, string phone_code_hash, string phone_code)
        {
            _phone_number = phone_number;
            _phone_code_hash = phone_code_hash;
            _phone_code = phone_code;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x70c32edb);
            Serializers.String.Write(writer, _phone_number);
            Serializers.String.Write(writer, _phone_code_hash);
            Serializers.String.Write(writer, _phone_code);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<User>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_UpdateDeviceLockedRequest : MTProtoRequest
    {
        int _period;

        public bool result;

        public Account_UpdateDeviceLockedRequest(int period)
        {
            _period = period;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x38df3532);
            writer.Write(_period);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_GetAuthorizationsRequest : MTProtoRequest
    {
        public account_Authorizations result;

        public Account_GetAuthorizationsRequest()
        {
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xe320c158);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<account_Authorizations>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_ResetAuthorizationRequest : MTProtoRequest
    {
        long _hash;

        public bool result;

        public Account_ResetAuthorizationRequest(long hash)
        {
            _hash = hash;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xdf77f3bc);
            writer.Write(_hash);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_GetPasswordRequest : MTProtoRequest
    {
        public account_Password result;

        public Account_GetPasswordRequest()
        {
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x548a30f5);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<account_Password>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_GetPasswordSettingsRequest : MTProtoRequest
    {
        byte[] _current_password_hash;

        public account_PasswordSettings result;

        public Account_GetPasswordSettingsRequest(byte[] current_password_hash)
        {
            _current_password_hash = current_password_hash;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xbc8d11bb);
            Serializers.Bytes.Write(writer, _current_password_hash);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<account_PasswordSettings>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Account_UpdatePasswordSettingsRequest : MTProtoRequest
    {
        byte[] _current_password_hash;
        account_PasswordInputSettings _new_settings;

        public bool result;

        public Account_UpdatePasswordSettingsRequest(byte[] current_password_hash, account_PasswordInputSettings new_settings)
        {
            _current_password_hash = current_password_hash;
            _new_settings = new_settings;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xfa7c4b86);
            Serializers.Bytes.Write(writer, _current_password_hash);
            _new_settings.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Users_GetUsersRequest : MTProtoRequest
    {
        List<InputUser> _id;

        public List<User> result;

        public Users_GetUsersRequest(List<InputUser> id)
        {
            _id = id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xd91a548);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_id.Count);
            foreach (InputUser id_element in _id)
                id_element.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int result_count = reader.ReadInt32();
            result = new List<User>(result_count);
            for (int result_index = 0; result_index < result_count; result_index++)
                result.Add(TL.Parse<User>(reader));
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Users_GetFullUserRequest : MTProtoRequest
    {
        InputUser _id;

        public UserFull result;

        public Users_GetFullUserRequest(InputUser id)
        {
            _id = id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xca30a5b1);
            _id.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<UserFull>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Contacts_GetStatusesRequest : MTProtoRequest
    {
        public List<ContactStatus> result;

        public Contacts_GetStatusesRequest()
        {
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xc4a353ee);
        }

        public override void OnResponse(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int result_count = reader.ReadInt32();
            result = new List<ContactStatus>(result_count);
            for (int result_index = 0; result_index < result_count; result_index++)
                result.Add(TL.Parse<ContactStatus>(reader));
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Contacts_GetContactsRequest : MTProtoRequest
    {
        string _hash;

        public contacts_Contacts result;

        public Contacts_GetContactsRequest(string hash)
        {
            _hash = hash;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x22c6aa08);
            Serializers.String.Write(writer, _hash);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<contacts_Contacts>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Contacts_ImportContactsRequest : MTProtoRequest
    {
        List<InputContact> _contacts;
        bool _replace;

        public contacts_ImportedContacts result;

        public Contacts_ImportContactsRequest(List<InputContact> contacts, bool replace)
        {
            _contacts = contacts;
            _replace = replace;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xda30b32d);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_contacts.Count);
            foreach (InputContact contacts_element in _contacts)
                contacts_element.Write(writer);
            writer.Write(_replace ? 0x997275b5 : 0xbc799737);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<contacts_ImportedContacts>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Contacts_GetSuggestedRequest : MTProtoRequest
    {
        int _limit;

        public contacts_Suggested result;

        public Contacts_GetSuggestedRequest(int limit)
        {
            _limit = limit;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xcd773428);
            writer.Write(_limit);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<contacts_Suggested>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Contacts_DeleteContactRequest : MTProtoRequest
    {
        InputUser _id;

        public contacts_Link result;

        public Contacts_DeleteContactRequest(InputUser id)
        {
            _id = id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x8e953744);
            _id.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<contacts_Link>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Contacts_DeleteContactsRequest : MTProtoRequest
    {
        List<InputUser> _id;

        public bool result;

        public Contacts_DeleteContactsRequest(List<InputUser> id)
        {
            _id = id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x59ab389e);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_id.Count);
            foreach (InputUser id_element in _id)
                id_element.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Contacts_BlockRequest : MTProtoRequest
    {
        InputUser _id;

        public bool result;

        public Contacts_BlockRequest(InputUser id)
        {
            _id = id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x332b49fc);
            _id.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Contacts_UnblockRequest : MTProtoRequest
    {
        InputUser _id;

        public bool result;

        public Contacts_UnblockRequest(InputUser id)
        {
            _id = id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xe54100bd);
            _id.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Contacts_GetBlockedRequest : MTProtoRequest
    {
        int _offset;
        int _limit;

        public contacts_Blocked result;

        public Contacts_GetBlockedRequest(int offset, int limit)
        {
            _offset = offset;
            _limit = limit;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xf57c350f);
            writer.Write(_offset);
            writer.Write(_limit);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<contacts_Blocked>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Contacts_ExportCardRequest : MTProtoRequest
    {
        public List<int> result;

        public Contacts_ExportCardRequest()
        {
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x84e53737);
        }

        public override void OnResponse(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int result_count = reader.ReadInt32();
            result = new List<int>(result_count);
            for (int result_index = 0; result_index < result_count; result_index++)
                result.Add(reader.ReadInt32());
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Contacts_ImportCardRequest : MTProtoRequest
    {
        List<int> _export_card;

        public User result;

        public Contacts_ImportCardRequest(List<int> export_card)
        {
            _export_card = export_card;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x4fe196fe);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_export_card.Count);
            foreach (int export_card_element in _export_card)
                writer.Write(export_card_element);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<User>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Contacts_SearchRequest : MTProtoRequest
    {
        string _q;
        int _limit;

        public contacts_Found result;

        public Contacts_SearchRequest(string q, int limit)
        {
            _q = q;
            _limit = limit;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x11f812d8);
            Serializers.String.Write(writer, _q);
            writer.Write(_limit);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<contacts_Found>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Contacts_ResolveUsernameRequest : MTProtoRequest
    {
        string _username;

        public contacts_ResolvedPeer result;

        public Contacts_ResolveUsernameRequest(string username)
        {
            _username = username;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xf93ccba3);
            Serializers.String.Write(writer, _username);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<contacts_ResolvedPeer>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_GetMessagesRequest : MTProtoRequest
    {
        List<int> _id;

        public messages_Messages result;

        public Messages_GetMessagesRequest(List<int> id)
        {
            _id = id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x4222fa74);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_id.Count);
            foreach (int id_element in _id)
                writer.Write(id_element);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_Messages>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_GetDialogsRequest : MTProtoRequest
    {
        int _offset;
        int _limit;

        public messages_Dialogs result;

        public Messages_GetDialogsRequest(int offset, int limit)
        {
            _offset = offset;
            _limit = limit;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x859b3d3c);
            writer.Write(_offset);
            writer.Write(_limit);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_Dialogs>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_GetHistoryRequest : MTProtoRequest
    {
        InputPeer _peer;
        int _offset_id;
        int _add_offset;
        int _limit;
        int _max_id;
        int _min_id;

        public messages_Messages result;

        public Messages_GetHistoryRequest(InputPeer peer, int offset_id, int add_offset, int limit, int max_id, int min_id)
        {
            _peer = peer;
            _offset_id = offset_id;
            _add_offset = add_offset;
            _limit = limit;
            _max_id = max_id;
            _min_id = min_id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x8a8ec2da);
            _peer.Write(writer);
            writer.Write(_offset_id);
            writer.Write(_add_offset);
            writer.Write(_limit);
            writer.Write(_max_id);
            writer.Write(_min_id);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_Messages>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_SearchRequest : MTProtoRequest
    {
        int _flags;
        InputPeer _peer;
        string _q;
        MessagesFilter _filter;
        int _min_date;
        int _max_date;
        int _offset;
        int _max_id;
        int _limit;

        public messages_Messages result;

        public Messages_SearchRequest(int flags, InputPeer peer, string q, MessagesFilter filter, int min_date, int max_date, int offset, int max_id, int limit)
        {
            _flags = flags;
            _peer = peer;
            _q = q;
            _filter = filter;
            _min_date = min_date;
            _max_date = max_date;
            _offset = offset;
            _max_id = max_id;
            _limit = limit;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xd4569248);
            writer.Write(_flags);
            _peer.Write(writer);
            Serializers.String.Write(writer, _q);
            _filter.Write(writer);
            writer.Write(_min_date);
            writer.Write(_max_date);
            writer.Write(_offset);
            writer.Write(_max_id);
            writer.Write(_limit);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_Messages>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_ReadHistoryRequest : MTProtoRequest
    {
        InputPeer _peer;
        int _max_id;
        int _offset;

        public messages_AffectedHistory result;

        public Messages_ReadHistoryRequest(InputPeer peer, int max_id, int offset)
        {
            _peer = peer;
            _max_id = max_id;
            _offset = offset;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xb04f2510);
            _peer.Write(writer);
            writer.Write(_max_id);
            writer.Write(_offset);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_AffectedHistory>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_DeleteHistoryRequest : MTProtoRequest
    {
        InputPeer _peer;
        int _offset;

        public messages_AffectedHistory result;

        public Messages_DeleteHistoryRequest(InputPeer peer, int offset)
        {
            _peer = peer;
            _offset = offset;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xf4f8fb61);
            _peer.Write(writer);
            writer.Write(_offset);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_AffectedHistory>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_DeleteMessagesRequest : MTProtoRequest
    {
        List<int> _id;

        public messages_AffectedMessages result;

        public Messages_DeleteMessagesRequest(List<int> id)
        {
            _id = id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xa5f18925);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_id.Count);
            foreach (int id_element in _id)
                writer.Write(id_element);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_AffectedMessages>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_ReceivedMessagesRequest : MTProtoRequest
    {
        int _max_id;

        public List<ReceivedNotifyMessage> result;

        public Messages_ReceivedMessagesRequest(int max_id)
        {
            _max_id = max_id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x5a954c0);
            writer.Write(_max_id);
        }

        public override void OnResponse(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int result_count = reader.ReadInt32();
            result = new List<ReceivedNotifyMessage>(result_count);
            for (int result_index = 0; result_index < result_count; result_index++)
                result.Add(TL.Parse<ReceivedNotifyMessage>(reader));
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_SetTypingRequest : MTProtoRequest
    {
        InputPeer _peer;
        SendMessageAction _action;

        public bool result;

        public Messages_SetTypingRequest(InputPeer peer, SendMessageAction action)
        {
            _peer = peer;
            _action = action;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xa3825e50);
            _peer.Write(writer);
            _action.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_SendMessageRequest : MTProtoRequest
    {
        int _flags;
        InputPeer _peer;
        int? _reply_to_msg_id;
        string _message;
        long _random_id;
        ReplyMarkup _reply_markup;
        List<MessageEntity> _entities;

        public Updates result;

        public Messages_SendMessageRequest(int flags, InputPeer peer, int? reply_to_msg_id, string message, long random_id, ReplyMarkup reply_markup, List<MessageEntity> entities)
        {
            _flags = flags;
            _peer = peer;
            _reply_to_msg_id = reply_to_msg_id;
            _message = message;
            _random_id = random_id;
            _reply_markup = reply_markup;
            _entities = entities;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xfa88427a);
            writer.Write(_flags);
            _peer.Write(writer);
            if (_reply_to_msg_id != null)
            {
                writer.Write(_reply_to_msg_id.Value);
            }
            Serializers.String.Write(writer, _message);
            writer.Write(_random_id);
            if (_reply_markup != null)
            {
                _reply_markup.Write(writer);
            }
            if (_entities != null)
            {
                writer.Write(0x1cb5c415); // vector code
                writer.Write(_entities.Count);
                foreach (MessageEntity entities_element in _entities)
                    entities_element.Write(writer);
            }
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_SendMediaRequest : MTProtoRequest
    {
        int _flags;
        InputPeer _peer;
        int? _reply_to_msg_id;
        InputMedia _media;
        long _random_id;
        ReplyMarkup _reply_markup;

        public Updates result;

        public Messages_SendMediaRequest(int flags, InputPeer peer, int? reply_to_msg_id, InputMedia media, long random_id, ReplyMarkup reply_markup)
        {
            _flags = flags;
            _peer = peer;
            _reply_to_msg_id = reply_to_msg_id;
            _media = media;
            _random_id = random_id;
            _reply_markup = reply_markup;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xc8f16791);
            writer.Write(_flags);
            _peer.Write(writer);
            if (_reply_to_msg_id != null)
            {
                writer.Write(_reply_to_msg_id.Value);
            }
            _media.Write(writer);
            writer.Write(_random_id);
            if (_reply_markup != null)
            {
                _reply_markup.Write(writer);
            }
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_ForwardMessagesRequest : MTProtoRequest
    {
        int _flags;
        InputPeer _from_peer;
        List<int> _id;
        List<long> _random_id;
        InputPeer _to_peer;

        public Updates result;

        public Messages_ForwardMessagesRequest(int flags, InputPeer from_peer, List<int> id, List<long> random_id, InputPeer to_peer)
        {
            _flags = flags;
            _from_peer = from_peer;
            _id = id;
            _random_id = random_id;
            _to_peer = to_peer;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x708e0195);
            writer.Write(_flags);
            _from_peer.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_id.Count);
            foreach (int id_element in _id)
                writer.Write(id_element);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_random_id.Count);
            foreach (long random_id_element in _random_id)
                writer.Write(random_id_element);
            _to_peer.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_ReportSpamRequest : MTProtoRequest
    {
        InputPeer _peer;

        public bool result;

        public Messages_ReportSpamRequest(InputPeer peer)
        {
            _peer = peer;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xcf1592db);
            _peer.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_GetChatsRequest : MTProtoRequest
    {
        List<int> _id;

        public messages_Chats result;

        public Messages_GetChatsRequest(List<int> id)
        {
            _id = id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x3c6aa187);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_id.Count);
            foreach (int id_element in _id)
                writer.Write(id_element);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_Chats>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_GetFullChatRequest : MTProtoRequest
    {
        int _chat_id;

        public messages_ChatFull result;

        public Messages_GetFullChatRequest(int chat_id)
        {
            _chat_id = chat_id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x3b831c66);
            writer.Write(_chat_id);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_ChatFull>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_EditChatTitleRequest : MTProtoRequest
    {
        int _chat_id;
        string _title;

        public Updates result;

        public Messages_EditChatTitleRequest(int chat_id, string title)
        {
            _chat_id = chat_id;
            _title = title;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xdc452855);
            writer.Write(_chat_id);
            Serializers.String.Write(writer, _title);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_EditChatPhotoRequest : MTProtoRequest
    {
        int _chat_id;
        InputChatPhoto _photo;

        public Updates result;

        public Messages_EditChatPhotoRequest(int chat_id, InputChatPhoto photo)
        {
            _chat_id = chat_id;
            _photo = photo;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xca4c79d8);
            writer.Write(_chat_id);
            _photo.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_AddChatUserRequest : MTProtoRequest
    {
        int _chat_id;
        InputUser _user_id;
        int _fwd_limit;

        public Updates result;

        public Messages_AddChatUserRequest(int chat_id, InputUser user_id, int fwd_limit)
        {
            _chat_id = chat_id;
            _user_id = user_id;
            _fwd_limit = fwd_limit;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xf9a0aa09);
            writer.Write(_chat_id);
            _user_id.Write(writer);
            writer.Write(_fwd_limit);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_DeleteChatUserRequest : MTProtoRequest
    {
        int _chat_id;
        InputUser _user_id;

        public Updates result;

        public Messages_DeleteChatUserRequest(int chat_id, InputUser user_id)
        {
            _chat_id = chat_id;
            _user_id = user_id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xe0611f16);
            writer.Write(_chat_id);
            _user_id.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_CreateChatRequest : MTProtoRequest
    {
        List<InputUser> _users;
        string _title;

        public Updates result;

        public Messages_CreateChatRequest(List<InputUser> users, string title)
        {
            _users = users;
            _title = title;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x9cb126e);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_users.Count);
            foreach (InputUser users_element in _users)
                users_element.Write(writer);
            Serializers.String.Write(writer, _title);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_ForwardMessageRequest : MTProtoRequest
    {
        InputPeer _peer;
        int _id;
        long _random_id;

        public Updates result;

        public Messages_ForwardMessageRequest(InputPeer peer, int id, long random_id)
        {
            _peer = peer;
            _id = id;
            _random_id = random_id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x33963bf9);
            _peer.Write(writer);
            writer.Write(_id);
            writer.Write(_random_id);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_SendBroadcastRequest : MTProtoRequest
    {
        List<InputUser> _contacts;
        List<long> _random_id;
        string _message;
        InputMedia _media;

        public Updates result;

        public Messages_SendBroadcastRequest(List<InputUser> contacts, List<long> random_id, string message, InputMedia media)
        {
            _contacts = contacts;
            _random_id = random_id;
            _message = message;
            _media = media;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xbf73f4da);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_contacts.Count);
            foreach (InputUser contacts_element in _contacts)
                contacts_element.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_random_id.Count);
            foreach (long random_id_element in _random_id)
                writer.Write(random_id_element);
            Serializers.String.Write(writer, _message);
            _media.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_GetDhConfigRequest : MTProtoRequest
    {
        int _version;
        int _random_length;

        public messages_DhConfig result;

        public Messages_GetDhConfigRequest(int version, int random_length)
        {
            _version = version;
            _random_length = random_length;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x26cf8950);
            writer.Write(_version);
            writer.Write(_random_length);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_DhConfig>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_RequestEncryptionRequest : MTProtoRequest
    {
        InputUser _user_id;
        int _random_id;
        byte[] _g_a;

        public EncryptedChat result;

        public Messages_RequestEncryptionRequest(InputUser user_id, int random_id, byte[] g_a)
        {
            _user_id = user_id;
            _random_id = random_id;
            _g_a = g_a;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xf64daf43);
            _user_id.Write(writer);
            writer.Write(_random_id);
            Serializers.Bytes.Write(writer, _g_a);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<EncryptedChat>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_AcceptEncryptionRequest : MTProtoRequest
    {
        InputEncryptedChat _peer;
        byte[] _g_b;
        long _key_fingerprint;

        public EncryptedChat result;

        public Messages_AcceptEncryptionRequest(InputEncryptedChat peer, byte[] g_b, long key_fingerprint)
        {
            _peer = peer;
            _g_b = g_b;
            _key_fingerprint = key_fingerprint;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x3dbc0415);
            _peer.Write(writer);
            Serializers.Bytes.Write(writer, _g_b);
            writer.Write(_key_fingerprint);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<EncryptedChat>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_DiscardEncryptionRequest : MTProtoRequest
    {
        int _chat_id;

        public bool result;

        public Messages_DiscardEncryptionRequest(int chat_id)
        {
            _chat_id = chat_id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xedd923c5);
            writer.Write(_chat_id);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_SetEncryptedTypingRequest : MTProtoRequest
    {
        InputEncryptedChat _peer;
        bool _typing;

        public bool result;

        public Messages_SetEncryptedTypingRequest(InputEncryptedChat peer, bool typing)
        {
            _peer = peer;
            _typing = typing;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x791451ed);
            _peer.Write(writer);
            writer.Write(_typing ? 0x997275b5 : 0xbc799737);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_ReadEncryptedHistoryRequest : MTProtoRequest
    {
        InputEncryptedChat _peer;
        int _max_date;

        public bool result;

        public Messages_ReadEncryptedHistoryRequest(InputEncryptedChat peer, int max_date)
        {
            _peer = peer;
            _max_date = max_date;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x7f4b690a);
            _peer.Write(writer);
            writer.Write(_max_date);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_SendEncryptedRequest : MTProtoRequest
    {
        InputEncryptedChat _peer;
        long _random_id;
        byte[] _data;

        public messages_SentEncryptedMessage result;

        public Messages_SendEncryptedRequest(InputEncryptedChat peer, long random_id, byte[] data)
        {
            _peer = peer;
            _random_id = random_id;
            _data = data;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xa9776773);
            _peer.Write(writer);
            writer.Write(_random_id);
            Serializers.Bytes.Write(writer, _data);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_SentEncryptedMessage>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_SendEncryptedFileRequest : MTProtoRequest
    {
        InputEncryptedChat _peer;
        long _random_id;
        byte[] _data;
        InputEncryptedFile _file;

        public messages_SentEncryptedMessage result;

        public Messages_SendEncryptedFileRequest(InputEncryptedChat peer, long random_id, byte[] data, InputEncryptedFile file)
        {
            _peer = peer;
            _random_id = random_id;
            _data = data;
            _file = file;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x9a901b66);
            _peer.Write(writer);
            writer.Write(_random_id);
            Serializers.Bytes.Write(writer, _data);
            _file.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_SentEncryptedMessage>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_SendEncryptedServiceRequest : MTProtoRequest
    {
        InputEncryptedChat _peer;
        long _random_id;
        byte[] _data;

        public messages_SentEncryptedMessage result;

        public Messages_SendEncryptedServiceRequest(InputEncryptedChat peer, long random_id, byte[] data)
        {
            _peer = peer;
            _random_id = random_id;
            _data = data;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x32d439a4);
            _peer.Write(writer);
            writer.Write(_random_id);
            Serializers.Bytes.Write(writer, _data);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_SentEncryptedMessage>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_ReceivedQueueRequest : MTProtoRequest
    {
        int _max_qts;

        public List<long> result;

        public Messages_ReceivedQueueRequest(int max_qts)
        {
            _max_qts = max_qts;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x55a5bb66);
            writer.Write(_max_qts);
        }

        public override void OnResponse(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int result_count = reader.ReadInt32();
            result = new List<long>(result_count);
            for (int result_index = 0; result_index < result_count; result_index++)
                result.Add(reader.ReadInt64());
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_ReadMessageContentsRequest : MTProtoRequest
    {
        List<int> _id;

        public messages_AffectedMessages result;

        public Messages_ReadMessageContentsRequest(List<int> id)
        {
            _id = id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x36a73f77);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_id.Count);
            foreach (int id_element in _id)
                writer.Write(id_element);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_AffectedMessages>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_GetStickersRequest : MTProtoRequest
    {
        string _emoticon;
        string _hash;

        public messages_Stickers result;

        public Messages_GetStickersRequest(string emoticon, string hash)
        {
            _emoticon = emoticon;
            _hash = hash;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xae22e045);
            Serializers.String.Write(writer, _emoticon);
            Serializers.String.Write(writer, _hash);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_Stickers>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_GetAllStickersRequest : MTProtoRequest
    {
        string _hash;

        public messages_AllStickers result;

        public Messages_GetAllStickersRequest(string hash)
        {
            _hash = hash;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xaa3bc868);
            Serializers.String.Write(writer, _hash);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_AllStickers>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_GetWebPagePreviewRequest : MTProtoRequest
    {
        string _message;

        public MessageMedia result;

        public Messages_GetWebPagePreviewRequest(string message)
        {
            _message = message;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x25223e24);
            Serializers.String.Write(writer, _message);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<MessageMedia>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_ExportChatInviteRequest : MTProtoRequest
    {
        int _chat_id;

        public ExportedChatInvite result;

        public Messages_ExportChatInviteRequest(int chat_id)
        {
            _chat_id = chat_id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x7d885289);
            writer.Write(_chat_id);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<ExportedChatInvite>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_CheckChatInviteRequest : MTProtoRequest
    {
        string _hash;

        public ChatInvite result;

        public Messages_CheckChatInviteRequest(string hash)
        {
            _hash = hash;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x3eadb1bb);
            Serializers.String.Write(writer, _hash);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<ChatInvite>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_ImportChatInviteRequest : MTProtoRequest
    {
        string _hash;

        public Updates result;

        public Messages_ImportChatInviteRequest(string hash)
        {
            _hash = hash;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x6c50051c);
            Serializers.String.Write(writer, _hash);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_GetStickerSetRequest : MTProtoRequest
    {
        InputStickerSet _stickerset;

        public messages_StickerSet result;

        public Messages_GetStickerSetRequest(InputStickerSet stickerset)
        {
            _stickerset = stickerset;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x2619a90e);
            _stickerset.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_StickerSet>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_InstallStickerSetRequest : MTProtoRequest
    {
        InputStickerSet _stickerset;
        bool _disabled;

        public bool result;

        public Messages_InstallStickerSetRequest(InputStickerSet stickerset, bool disabled)
        {
            _stickerset = stickerset;
            _disabled = disabled;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x7b30c3a6);
            _stickerset.Write(writer);
            writer.Write(_disabled ? 0x997275b5 : 0xbc799737);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_UninstallStickerSetRequest : MTProtoRequest
    {
        InputStickerSet _stickerset;

        public bool result;

        public Messages_UninstallStickerSetRequest(InputStickerSet stickerset)
        {
            _stickerset = stickerset;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xf96e55de);
            _stickerset.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_StartBotRequest : MTProtoRequest
    {
        InputUser _bot;
        int _chat_id;
        long _random_id;
        string _start_param;

        public Updates result;

        public Messages_StartBotRequest(InputUser bot, int chat_id, long random_id, string start_param)
        {
            _bot = bot;
            _chat_id = chat_id;
            _random_id = random_id;
            _start_param = start_param;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x1b3e0ffc);
            _bot.Write(writer);
            writer.Write(_chat_id);
            writer.Write(_random_id);
            Serializers.String.Write(writer, _start_param);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Messages_GetMessagesViewsRequest : MTProtoRequest
    {
        InputPeer _peer;
        List<int> _id;
        bool _increment;

        public List<int> result;

        public Messages_GetMessagesViewsRequest(InputPeer peer, List<int> id, bool increment)
        {
            _peer = peer;
            _id = id;
            _increment = increment;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xc4c8a55d);
            _peer.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_id.Count);
            foreach (int id_element in _id)
                writer.Write(id_element);
            writer.Write(_increment ? 0x997275b5 : 0xbc799737);
        }

        public override void OnResponse(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int result_count = reader.ReadInt32();
            result = new List<int>(result_count);
            for (int result_index = 0; result_index < result_count; result_index++)
                result.Add(reader.ReadInt32());
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Updates_GetStateRequest : MTProtoRequest
    {
        public updates_State result;

        public Updates_GetStateRequest()
        {
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xedd4882a);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<updates_State>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Updates_GetDifferenceRequest : MTProtoRequest
    {
        int _pts;
        int _date;
        int _qts;

        public updates_Difference result;

        public Updates_GetDifferenceRequest(int pts, int date, int qts)
        {
            _pts = pts;
            _date = date;
            _qts = qts;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xa041495);
            writer.Write(_pts);
            writer.Write(_date);
            writer.Write(_qts);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<updates_Difference>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Updates_GetChannelDifferenceRequest : MTProtoRequest
    {
        InputChannel _channel;
        ChannelMessagesFilter _filter;
        int _pts;
        int _limit;

        public updates_ChannelDifference result;

        public Updates_GetChannelDifferenceRequest(InputChannel channel, ChannelMessagesFilter filter, int pts, int limit)
        {
            _channel = channel;
            _filter = filter;
            _pts = pts;
            _limit = limit;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xbb32d7c0);
            _channel.Write(writer);
            _filter.Write(writer);
            writer.Write(_pts);
            writer.Write(_limit);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<updates_ChannelDifference>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Photos_UpdateProfilePhotoRequest : MTProtoRequest
    {
        InputPhoto _id;
        InputPhotoCrop _crop;

        public UserProfilePhoto result;

        public Photos_UpdateProfilePhotoRequest(InputPhoto id, InputPhotoCrop crop)
        {
            _id = id;
            _crop = crop;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xeef579a0);
            _id.Write(writer);
            _crop.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<UserProfilePhoto>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Photos_UploadProfilePhotoRequest : MTProtoRequest
    {
        InputFile _file;
        string _caption;
        InputGeoPoint _geo_point;
        InputPhotoCrop _crop;

        public photos_Photo result;

        public Photos_UploadProfilePhotoRequest(InputFile file, string caption, InputGeoPoint geo_point, InputPhotoCrop crop)
        {
            _file = file;
            _caption = caption;
            _geo_point = geo_point;
            _crop = crop;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xd50f9c88);
            _file.Write(writer);
            Serializers.String.Write(writer, _caption);
            _geo_point.Write(writer);
            _crop.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<photos_Photo>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Photos_DeletePhotosRequest : MTProtoRequest
    {
        List<InputPhoto> _id;

        public List<long> result;

        public Photos_DeletePhotosRequest(List<InputPhoto> id)
        {
            _id = id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x87cf7f2f);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_id.Count);
            foreach (InputPhoto id_element in _id)
                id_element.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            reader.ReadUInt32(); // vector code
            int result_count = reader.ReadInt32();
            result = new List<long>(result_count);
            for (int result_index = 0; result_index < result_count; result_index++)
                result.Add(reader.ReadInt64());
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Photos_GetUserPhotosRequest : MTProtoRequest
    {
        InputUser _user_id;
        int _offset;
        long _max_id;
        int _limit;

        public photos_Photos result;

        public Photos_GetUserPhotosRequest(InputUser user_id, int offset, long max_id, int limit)
        {
            _user_id = user_id;
            _offset = offset;
            _max_id = max_id;
            _limit = limit;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x91cd32a8);
            _user_id.Write(writer);
            writer.Write(_offset);
            writer.Write(_max_id);
            writer.Write(_limit);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<photos_Photos>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Upload_SaveFilePartRequest : MTProtoRequest
    {
        long _file_id;
        int _file_part;
        byte[] _bytes;

        public bool result;

        public Upload_SaveFilePartRequest(long file_id, int file_part, byte[] bytes)
        {
            _file_id = file_id;
            _file_part = file_part;
            _bytes = bytes;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xb304a621);
            writer.Write(_file_id);
            writer.Write(_file_part);
            Serializers.Bytes.Write(writer, _bytes);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Upload_GetFileRequest : MTProtoRequest
    {
        InputFileLocation _location;
        int _offset;
        int _limit;

        public upload_File result;

        public Upload_GetFileRequest(InputFileLocation location, int offset, int limit)
        {
            _location = location;
            _offset = offset;
            _limit = limit;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xe3a6cfb5);
            _location.Write(writer);
            writer.Write(_offset);
            writer.Write(_limit);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<upload_File>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Upload_SaveBigFilePartRequest : MTProtoRequest
    {
        long _file_id;
        int _file_part;
        int _file_total_parts;
        byte[] _bytes;

        public bool result;

        public Upload_SaveBigFilePartRequest(long file_id, int file_part, int file_total_parts, byte[] bytes)
        {
            _file_id = file_id;
            _file_part = file_part;
            _file_total_parts = file_total_parts;
            _bytes = bytes;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xde7b673d);
            writer.Write(_file_id);
            writer.Write(_file_part);
            writer.Write(_file_total_parts);
            Serializers.Bytes.Write(writer, _bytes);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Help_GetConfigRequest : MTProtoRequest
    {
        public Config result;

        public Help_GetConfigRequest()
        {
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xc4f9186b);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Config>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Help_GetNearestDcRequest : MTProtoRequest
    {
        public NearestDc result;

        public Help_GetNearestDcRequest()
        {
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x1fb33026);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<NearestDc>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Help_GetAppUpdateRequest : MTProtoRequest
    {
        string _device_model;
        string _system_version;
        string _app_version;
        string _lang_code;

        public help_AppUpdate result;

        public Help_GetAppUpdateRequest(string device_model, string system_version, string app_version, string lang_code)
        {
            _device_model = device_model;
            _system_version = system_version;
            _app_version = app_version;
            _lang_code = lang_code;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xc812ac7e);
            Serializers.String.Write(writer, _device_model);
            Serializers.String.Write(writer, _system_version);
            Serializers.String.Write(writer, _app_version);
            Serializers.String.Write(writer, _lang_code);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<help_AppUpdate>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Help_SaveAppLogRequest : MTProtoRequest
    {
        List<InputAppEvent> _events;

        public bool result;

        public Help_SaveAppLogRequest(List<InputAppEvent> events)
        {
            _events = events;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x6f02f748);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_events.Count);
            foreach (InputAppEvent events_element in _events)
                events_element.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Help_GetInviteTextRequest : MTProtoRequest
    {
        string _lang_code;

        public help_InviteText result;

        public Help_GetInviteTextRequest(string lang_code)
        {
            _lang_code = lang_code;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xa4a95186);
            Serializers.String.Write(writer, _lang_code);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<help_InviteText>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Help_GetSupportRequest : MTProtoRequest
    {
        public help_Support result;

        public Help_GetSupportRequest()
        {
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x9cdf08cd);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<help_Support>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Help_GetAppChangelogRequest : MTProtoRequest
    {
        string _device_model;
        string _system_version;
        string _app_version;
        string _lang_code;

        public help_AppChangelog result;

        public Help_GetAppChangelogRequest(string device_model, string system_version, string app_version, string lang_code)
        {
            _device_model = device_model;
            _system_version = system_version;
            _app_version = app_version;
            _lang_code = lang_code;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x5bab7fb2);
            Serializers.String.Write(writer, _device_model);
            Serializers.String.Write(writer, _system_version);
            Serializers.String.Write(writer, _app_version);
            Serializers.String.Write(writer, _lang_code);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<help_AppChangelog>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_GetDialogsRequest : MTProtoRequest
    {
        int _offset;
        int _limit;

        public messages_Dialogs result;

        public Channels_GetDialogsRequest(int offset, int limit)
        {
            _offset = offset;
            _limit = limit;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xa9d3d249);
            writer.Write(_offset);
            writer.Write(_limit);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_Dialogs>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_GetImportantHistoryRequest : MTProtoRequest
    {
        InputChannel _channel;
        int _offset_id;
        int _add_offset;
        int _limit;
        int _max_id;
        int _min_id;

        public messages_Messages result;

        public Channels_GetImportantHistoryRequest(InputChannel channel, int offset_id, int add_offset, int limit, int max_id, int min_id)
        {
            _channel = channel;
            _offset_id = offset_id;
            _add_offset = add_offset;
            _limit = limit;
            _max_id = max_id;
            _min_id = min_id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xddb929cb);
            _channel.Write(writer);
            writer.Write(_offset_id);
            writer.Write(_add_offset);
            writer.Write(_limit);
            writer.Write(_max_id);
            writer.Write(_min_id);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_Messages>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_ReadHistoryRequest : MTProtoRequest
    {
        InputChannel _channel;
        int _max_id;

        public bool result;

        public Channels_ReadHistoryRequest(InputChannel channel, int max_id)
        {
            _channel = channel;
            _max_id = max_id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xcc104937);
            _channel.Write(writer);
            writer.Write(_max_id);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_DeleteMessagesRequest : MTProtoRequest
    {
        InputChannel _channel;
        List<int> _id;

        public messages_AffectedMessages result;

        public Channels_DeleteMessagesRequest(InputChannel channel, List<int> id)
        {
            _channel = channel;
            _id = id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x84c1fd4e);
            _channel.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_id.Count);
            foreach (int id_element in _id)
                writer.Write(id_element);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_AffectedMessages>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_DeleteUserHistoryRequest : MTProtoRequest
    {
        InputChannel _channel;
        InputUser _user_id;

        public messages_AffectedHistory result;

        public Channels_DeleteUserHistoryRequest(InputChannel channel, InputUser user_id)
        {
            _channel = channel;
            _user_id = user_id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xd10dd71b);
            _channel.Write(writer);
            _user_id.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_AffectedHistory>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_ReportSpamRequest : MTProtoRequest
    {
        InputChannel _channel;
        InputUser _user_id;
        List<int> _id;

        public bool result;

        public Channels_ReportSpamRequest(InputChannel channel, InputUser user_id, List<int> id)
        {
            _channel = channel;
            _user_id = user_id;
            _id = id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xfe087810);
            _channel.Write(writer);
            _user_id.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_id.Count);
            foreach (int id_element in _id)
                writer.Write(id_element);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_GetMessagesRequest : MTProtoRequest
    {
        InputChannel _channel;
        List<int> _id;

        public messages_Messages result;

        public Channels_GetMessagesRequest(InputChannel channel, List<int> id)
        {
            _channel = channel;
            _id = id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x93d7b347);
            _channel.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_id.Count);
            foreach (int id_element in _id)
                writer.Write(id_element);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_Messages>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_GetParticipantsRequest : MTProtoRequest
    {
        InputChannel _channel;
        ChannelParticipantsFilter _filter;
        int _offset;
        int _limit;

        public channels_ChannelParticipants result;

        public Channels_GetParticipantsRequest(InputChannel channel, ChannelParticipantsFilter filter, int offset, int limit)
        {
            _channel = channel;
            _filter = filter;
            _offset = offset;
            _limit = limit;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x24d98f92);
            _channel.Write(writer);
            _filter.Write(writer);
            writer.Write(_offset);
            writer.Write(_limit);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<channels_ChannelParticipants>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_GetParticipantRequest : MTProtoRequest
    {
        InputChannel _channel;
        InputUser _user_id;

        public channels_ChannelParticipant result;

        public Channels_GetParticipantRequest(InputChannel channel, InputUser user_id)
        {
            _channel = channel;
            _user_id = user_id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x546dd7a6);
            _channel.Write(writer);
            _user_id.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<channels_ChannelParticipant>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_GetChannelsRequest : MTProtoRequest
    {
        List<InputChannel> _id;

        public messages_Chats result;

        public Channels_GetChannelsRequest(List<InputChannel> id)
        {
            _id = id;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xa7f6bbb);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_id.Count);
            foreach (InputChannel id_element in _id)
                id_element.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_Chats>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_GetFullChannelRequest : MTProtoRequest
    {
        InputChannel _channel;

        public messages_ChatFull result;

        public Channels_GetFullChannelRequest(InputChannel channel)
        {
            _channel = channel;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x8736a09);
            _channel.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<messages_ChatFull>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_CreateChannelRequest : MTProtoRequest
    {
        int _flags;
        string _title;
        string _about;
        List<InputUser> _users;

        public Updates result;

        public Channels_CreateChannelRequest(int flags, string title, string about, List<InputUser> users)
        {
            _flags = flags;
            _title = title;
            _about = about;
            _users = users;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x5521d844);
            writer.Write(_flags);
            Serializers.String.Write(writer, _title);
            Serializers.String.Write(writer, _about);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_users.Count);
            foreach (InputUser users_element in _users)
                users_element.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_EditAboutRequest : MTProtoRequest
    {
        InputChannel _channel;
        string _about;

        public bool result;

        public Channels_EditAboutRequest(InputChannel channel, string about)
        {
            _channel = channel;
            _about = about;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x13e27f1e);
            _channel.Write(writer);
            Serializers.String.Write(writer, _about);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_EditAdminRequest : MTProtoRequest
    {
        InputChannel _channel;
        InputUser _user_id;
        ChannelParticipantRole _role;

        public bool result;

        public Channels_EditAdminRequest(InputChannel channel, InputUser user_id, ChannelParticipantRole role)
        {
            _channel = channel;
            _user_id = user_id;
            _role = role;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x52b16962);
            _channel.Write(writer);
            _user_id.Write(writer);
            _role.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_EditTitleRequest : MTProtoRequest
    {
        InputChannel _channel;
        string _title;

        public Updates result;

        public Channels_EditTitleRequest(InputChannel channel, string title)
        {
            _channel = channel;
            _title = title;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x566decd0);
            _channel.Write(writer);
            Serializers.String.Write(writer, _title);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_EditPhotoRequest : MTProtoRequest
    {
        InputChannel _channel;
        InputChatPhoto _photo;

        public Updates result;

        public Channels_EditPhotoRequest(InputChannel channel, InputChatPhoto photo)
        {
            _channel = channel;
            _photo = photo;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xf12e57c9);
            _channel.Write(writer);
            _photo.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_ToggleCommentsRequest : MTProtoRequest
    {
        InputChannel _channel;
        bool _enabled;

        public Updates result;

        public Channels_ToggleCommentsRequest(InputChannel channel, bool enabled)
        {
            _channel = channel;
            _enabled = enabled;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xaaa29e88);
            _channel.Write(writer);
            writer.Write(_enabled ? 0x997275b5 : 0xbc799737);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_CheckUsernameRequest : MTProtoRequest
    {
        InputChannel _channel;
        string _username;

        public bool result;

        public Channels_CheckUsernameRequest(InputChannel channel, string username)
        {
            _channel = channel;
            _username = username;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x10e6bd2c);
            _channel.Write(writer);
            Serializers.String.Write(writer, _username);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_UpdateUsernameRequest : MTProtoRequest
    {
        InputChannel _channel;
        string _username;

        public bool result;

        public Channels_UpdateUsernameRequest(InputChannel channel, string username)
        {
            _channel = channel;
            _username = username;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x3514b3de);
            _channel.Write(writer);
            Serializers.String.Write(writer, _username);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = reader.ReadUInt32() == 0x997275b5;
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_JoinChannelRequest : MTProtoRequest
    {
        InputChannel _channel;

        public Updates result;

        public Channels_JoinChannelRequest(InputChannel channel)
        {
            _channel = channel;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x24b524c5);
            _channel.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_LeaveChannelRequest : MTProtoRequest
    {
        InputChannel _channel;

        public Updates result;

        public Channels_LeaveChannelRequest(InputChannel channel)
        {
            _channel = channel;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xf836aa95);
            _channel.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_InviteToChannelRequest : MTProtoRequest
    {
        InputChannel _channel;
        List<InputUser> _users;

        public Updates result;

        public Channels_InviteToChannelRequest(InputChannel channel, List<InputUser> users)
        {
            _channel = channel;
            _users = users;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0x199f3a6c);
            _channel.Write(writer);
            writer.Write(0x1cb5c415); // vector code
            writer.Write(_users.Count);
            foreach (InputUser users_element in _users)
                users_element.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_KickFromChannelRequest : MTProtoRequest
    {
        InputChannel _channel;
        InputUser _user_id;
        bool _kicked;

        public Updates result;

        public Channels_KickFromChannelRequest(InputChannel channel, InputUser user_id, bool kicked)
        {
            _channel = channel;
            _user_id = user_id;
            _kicked = kicked;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xa672de14);
            _channel.Write(writer);
            _user_id.Write(writer);
            writer.Write(_kicked ? 0x997275b5 : 0xbc799737);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_ExportInviteRequest : MTProtoRequest
    {
        InputChannel _channel;

        public ExportedChatInvite result;

        public Channels_ExportInviteRequest(InputChannel channel)
        {
            _channel = channel;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xc7560885);
            _channel.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<ExportedChatInvite>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

    public class Channels_DeleteChannelRequest : MTProtoRequest
    {
        InputChannel _channel;

        public Updates result;

        public Channels_DeleteChannelRequest(InputChannel channel)
        {
            _channel = channel;
        }

        public override void OnSend(BinaryWriter writer)
        {
            writer.Write(0xc0111fe3);
            _channel.Write(writer);
        }

        public override void OnResponse(BinaryReader reader)
        {
            result = TL.Parse<Updates>(reader);
        }

        public override void OnException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public override bool Confirmed => true;
        public override bool Responded { get; }
    }

}