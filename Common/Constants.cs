namespace Common
{
    public static class AppConstant
    {
        public const string ApiKeyValue = "Pfe.ApiKey";
        public const string PfeWebAccessKeyValue = "PfeWeb.ApiKey";
        public const string PfeAdminPanelAccessKeyValue = "PfeAdmin.ApiKey";
        public static string ApiKeyHash = Utility.GetHashValue(ApiKeyValue);
        public static string PfeWebAccessKeyHash = Utility.GetHashValue(PfeWebAccessKeyValue);
        public static string PfeAdminPanelAccessKeyHash = Utility.GetHashValue(PfeAdminPanelAccessKeyValue);
        /// <summary>
        /// Slack user id which can be seen by all admins
        /// </summary>
        public const string CommonAdminUserId = "ed43b10a-ba2c-4673-989f-0a54eec729e9";
    }

    public static class ErrorMessage
    {
        public const string IntegrationKeyError = "Application Integration key error.";
        public const string ApplicationExceptionMessage = "An unexpected error occured.\nPlease try again later.";
        public const string RecordNotFound = "Record not found.";
        public const string TeacherNotFound = "Related teacher not found.";
        public const string SchoolNotFound = "Related school not found.";
        public const string StudentNotFound = "Related student not found.";
        public const string ProfileFilterNotFound = "Related profile filter found.";
        public const string NotAuthorized = "You are not authorized to perform the operation.";
        public const string ApiKeyNotFound = "Api key not found.";
        public const string JobApiKeyNotFound = "Job Api key not found.";
        public const string ChannelTypeNotFound = "Channel type key not found.";
        public const string ApiKeyIncorrect = "Given api key is incorrect.";
        public const string CannotUseSameUserOnCopyClaims = "Same users cannot be used to copy claims";
        public const string ChannelTypeIncorrect = "Given channel type is incorrect.";
        public const string UserNotFound = "User not found.";
        public const string UserEmailMismatch = "User/Email mismatch.";
        public const string PasswordResetSecurityCodeInvalid = "Security code invalid.";
        public const string PasswordResetRequestNotFound = "Password reset request not found.";
        public const string IncorrectusernameOrPassword = "Username or password is incorrect.";
        public const string UserEmailNotConfirmed = "Üyeliğiniz henüz aktiflestirilmemis. Lütfen kayıt olduğunuz mail adresinize gönderilen doğrulama maili ile üyeliğinizi aktiflestiriniz.";
        public const string UserNotActive = "Kullanıcı durumu aktif değil.";
        public const string UserEmailNotExists = "Mail adres alanı zounludur.";
        public const string PhoneNumberNotExists = "Telefon alanı zounludur.";
        public const string DeviceKeyNotExists = "DeviceKey alanı zounludur.";
        public const string EmailOrUserNameNotFound = "Girilen değer ile eslesen kullanıcı adı ya da email bulunamadı.";
        public const string RequestInvalid = "Invalid request.";
        public const string RequestNotFound = "Request body not found";
        public const string ClaimsNotFound = "You are not authorized to perform the operation.";
        public const string SourceUserHasNoClaims = "There is none claim to be copied";
        public const string SearchTypeNotFound = "Arama kriteri tipi bulunamadı.";
        public const string UserExists = "This user already exists.";
        public const string TeacherixUserPassCannotBeReset = "Teacherix users' pass cannot be reset. Try to reset your password on web app";
        public const string UserCannotCreated = "User cannot be created.";
        public const string EmailSendingFailure = "Email gönderimi basarısız oldu. Lütfen daha sonra tekrar deneyiniz.";
        public const string WrongVerificationLink = "Link geçerliliğini yitirmis.";
        public const string UserOrEmailNotFound = "Username or email cannot found";
        public const string EventNotStarted = "Sonuç girmek için maç sonunu bekleyiniz.";
        public const string DuplicatedProduct = "Bu ürün daha önce kaydedilmis.";
        public const string CommentNotSaved = "Yorum kaydetme islemi basarısız oldu.";
        public const string CommentAndPredictionsNotSaved = "Tahmin ve  yorum kaydetme islemi basarısız oldu.";
        public const string OddsNotFound = "Bahis bulunamadı.";
        public const string ChannelTypeNotAppropriate = "Sadece mobil bir device key izni bulunmaktadır.";
        public const string RecordNotSaved = "Veri kaydetme islemi basarısız oldu."; // generic not saved error message
        public const string RecordNotUpdated = "Veri güncelleme islemi basarısız oldu."; // generic not saved error message
        public const string UserDeviceNotFound = "Kayıtlı mobil device bulunamadı, bildirim gönderilemedi.";
        public const string MobileUserCouponCannotBeDeleted = "Mobil kullanıcıların olusturduğu kuponları silme yetkiniz bulunmamaktadır.";
        public const string CouponCannotBeCreatedWithGivenCriteria = "Girilen kriterlere uygun bir kupon olusturulamadı.";
        public const string CouponCreationHasError = "Kupon olusturma islemi sırasında hata alındı.\nLütfen daha sonra tekrar deneyiniz.";
        public const string CurrentPasswordWrong = "Mevcut sifreniz doğrulanamadı";
        public const string SchoolIdNotValid = "SchoolId is not valid";
        public const string TeacherIdNotValid = "TeacherId is not valid";
        public const string ProgramIdNotValid = "ProgramId is not valid";
        public const string StudentIdNotValid = "StudentId is not valid";
        public const string OrderIdNotValid = "Order is not valid";
        public const string OrderNotFound = "Order not found";
        public const string EducationIdNotValid = "EducationId is not valid";
        public const string DocumentIdNotValid = "Document Id Not Valid";
        public const string ProfileStatusIdNotValid = "ProfileStatusId is not valid";
        public const string StudentApplicationStatusNotValid = "StudentApplicationStatus is not valid";
        public const string OrderStatusIdNotValid = "OrderStatusId is not valid";
        public const string ProductIdNotValid = "ProductId is not valid";
        public const string ProductIdNotFound = "ProductId not found";
        public const string CampaignNotFound = "Campaign not found.";
        public const string PageDataSetNotValidated = "Page data set not validated.";
        public const string AuthenticationDataSetNotValidated = "Authentication data set not validated.";
        public const string PlanDataSetNotValidated = "Plan data set not validated.";
        public const string UserTypeDataSetNotValidated = "User type data set not validated.";
        public const string CampaignDateRangeNotValidated = "Campaign start date must be equal or smaller than end date.";
        public const string CampaignEndDateNotValidated = "Campaign end date must be equal or greater than today.";
        public const string CampaignTemplateNameNotValidated = "Campaign template can not include spaces.";
        public const string LoginRequestNotFound = "Login request not found";
        public const string SecurityCodeNotValid = "Security code is wrong or not valid.";
        public const string SecurityCodeExpired = "Security code has been expired.";
        public const string MailCountExceeded = "Max {0} mails can be sent at the same time.";
        public const string CitizenshipFilterCountExceeded = "Max {0} citizenship can be selected at the same time.";
        public const string CannotDeleteReservedAccount = "Reserved accounts cannot be deleted.";
        public const string RequiresReservedAccountForStaffCreation = "Only reserved email accounts are allowed for staff creation.";
        public const string CouponNotFound = "Coupon can not be found.";
        public const string CouponExpired = "Coupon has been expired.";
        public const string CouponUsed = "All coupons have been used.";
        public const string ProductNotFound = "Product can not be found.";
        public const string ProductTypeIdNotValid = "ProductTypeId is not valid";
        public const string PaymentSessionCannotBeCreated = "Payment session creation problem. Please try again later.";
        public const string SignatureNotValidated = "Given signature is not validated.";
    }

    public static class LoggingOperationPhrase
    {
        public const string NewEntity = "'{0}' entity has been created.";

        public const string ModifiedEntity = "'{0}' entity has been modified.";

        public const string DeletedEntity = "'{0}' entity has been deleted.";

        public const string Registration = "New user {0} has registered.";

        public const string TokenRequest = "User {0} generated new token";

        public const string PasswordResetRequest = "User {0} has requested a password reset.";

        public const string PasswordChanged = "User {0} has changed password.";

        public const string NotFound = "Object {0} not found.";
    }

    public static class NotificationTypeText
    {
        public const string Warning = "Warning";
        public const string General = "General";
        public const string Suggestion = "Suggestion";
    }

    public static class ContentTpye
    {
        public const string FormUrlencoded = "application/x-www-form-urlencoded";
    }

    public static class WebMethodTypeText
    {
        public const string Get = "Get";
        public const string Post = "Post";
        public const string Put = "Put";
    }

    public static class MailSubjects
    {
        public const string WireTransferApproved = "We have got your payment!";
        public const string UpgradedPlan = "Your plan has been upgraded!";
        public const string SecurityCodeRequest = "New security code request";
        public const string ResetPasswordLink = "Reset password link";
        public const string StudentApplicationNotStarted = "Complete scholarship application";
        public const string StudentApplicationNotPaid = "Scholarship application processing fee";
        public const string StudentApplicationNotUploaded = "Upload documents for scholarship";
        public const string StudentApplicationNotSubmitted = "Submit scholarship application for processing";
        public const string StudentApplicationGeneric = "Scholarship Information";
        public const string OrderExternalLinkCreated = "Your order is ready!";
        public const string ProfileMissingFields = "We need you to complete your profile";
    }

    /// <summary>
    /// Mail Template Names
    /// </summary>
    public static class MailTemplateNames
    {
        //apply for job
        public const string AfterTeacherAppliedSendMailToSchool = "after-teacher-applied-send-to-school.html";
        public const string AfterTeacherAppliedSendMailToTeacher = "after-teacher-applied-send-to-teacher.html";
        public const string AfterTeacherAppliedSendMailToAdmin = "after-teacher-applied-send-to-admin.html";

        //hire teacher
        public const string AfterSchoolHiredSendMailToSchool = "after-school-hired-send-to-school.html";
        public const string AfterSchoolHiredSendMailToAdmin = "after-school-hired-send-to-admin.html";
        public const string AfterSchoolHiredSendMailToTeacher = "after-school-hired-send-to-teacher.html";

        //payment
        public const string AfterTeacherSelectedFreePlanSendToTeacher = "after-teacher-selected-free-plan-send-to-teacher.html";
        public const string AfterSuccessedPaymentSendToTeacher = "after-successed-payment-send-to-teacher.html";
        public const string AfterFailedPaymentSendToTeacher = "after-failed-payment-send-to-teacher.html";

        //internship
        public const string InternshipFormEmailSubmission = "internship-form-email-submission.html";

        //profile notification mail
        public const string ProfileActiveInformationSendToSchool = "profile-active-information-school.html";
        public const string ProfileActiveInformationSendToTeacher = "profile-active-information-teacher.html";
        public const string ProfileDeclinedInformationSendToSchool = "profile-declined-information-school.html";
        public const string ProfileDeclinedInformationSendToTeacher = "profile-declined-information-teacher.html";
        public const string ProfileMissingFieldsSendToTeacher = "required-profile-info-teacher.html";

        //upgrade plan mail
        public const string UpgradedPlanSendToSchool = "upgraded-plan-send-to-school.html";
        public const string UpgradedPlanSendToTeacher = "upgraded-plan-send-to-teacher.html";

        //wire transfer approved mail
        public const string WireTransferApprovedSendToAll = "wire-transfer-approved-send-to-all.html";

        //external link for order
        public const string AfterOrderExternalLinkCreatedSendToAll = "after-order-external-link-created-send-to-all.html";
    }

    /// <summary>
    /// dbo.[ProfileStatus] table Ids
    /// </summary>
    public static class ProfileStatus
    {
        public const string Declined = "48E0CE16-68D6-46F2-9FDF-681E6C46B413";
        public const string Active = "9EB52147-A3CD-433E-9645-794086D63786";
        public const string InProgress = "1BFA263C-DCEB-44DC-84F6-7D306D8C3C40";
        public const string InProgressCompleted = "2D4A094A-C26D-42D1-B8AF-80A03F8AA0F0";
        public const string PendingApproval = "B1FA7D2C-F8C3-413A-9580-B4659D0F65EF";
        public const string Passive = "5017B6FB-541E-4905-BCCF-ECFAED91F250";
    }

    public static class Role
    {
        public const string Owner = "owner";
        public const string Admin = "admin";
    }

    public static class UserHiddenClaimType
    {
        public const string Country = "hidden_Country";
    }

    public static class UserClaimValue
    {
        //Last ID is => 58 (58_staff_reset_pass_mail)

        //teacher actions
        public const string TeacherSearch = "1_teacher_search";
        public const string TeacherDetail = "2_teacher_detail";
        public const string TeacherProfileUpdate = "3_teacher_profile_update";
        public const string TeacherReferenceUpdate = "4_teacher_reference_update";
        public const string TeacherDocumentUpdate = "5_teacher_document_update";
        public const string TeacherDelete = "6_teacher_delete";
        public const string TeacherUpgradeAccount = "7_teacher_upgrade_account";
        public const string TeacherActionHistory = "8_teacher_action_history";
        public const string TeacherFieldsUpdate = "18_teacher_fields_update";
        public const string TeacherNotificationMail = "38_teacher_notification_mail";
        public const string TeacherSms = "39_teacher_sms";
        public const string TeacherBulkSms = "40_teacher_bulk_sms";
        public const string TeacherPoolAction = "44_teacher_pool_action";
        public const string TeacherPoolUpdate = "45_teacher_pool_update";
        public const string TeacherWireTransferApprove = "46_teacher_wiretransfer_approve";

        //school actions
        public const string SchoolSearch = "9_school_search";
        public const string SchoolDetail = "10_school_detail";
        public const string SchoolProfileUpdate = "11_school_profile_update";
        public const string SchoolDelete = "12_school_delete";
        public const string SchoolActionHistory = "17_school_action_history";
        public const string SchoolPooledUsers = "47_school_pooled_users";
        public const string SchoolWireTransferApprove = "48_school_wiretransfer_approve";
        public const string SchoolPropertiesUpdate = "53_school_properties_update";

        //job actions
        public const string JobSearch = "13_job_search";
        public const string JobApplicantSearch = "54_job_applicant_search";

        //campaign actions 
        public const string CampaignAddEdit = "14_campaign_add_edit";
        public const string CampaignDelete = "15_campaign_delete";
        public const string CampaignSearch = "16_campaign_search";

        //user actions
        public const string UserLogSearch = "19_userlog_search";

        //student actions
        public const string StudentSearch = "20_student_search";
        public const string StudentDetail = "21_student_detail";
        public const string StudentDelete = "22_student_delete";
        public const string StudentActionHistory = "23_student_action_history";
        public const string StudentUpdateApplicationStatus = "24_student_update_app_status";
        public const string StudentDocumentUpdate = "25_student_document_update";
        public const string StudentNotificationMail = "26_student_notification_mail";
        public const string StudentFieldsUpdate = "27_student_fields_update";
        public const string StudentSms = "28_student_sms";
        public const string StudentBulkSms = "29_student_bulk_sms";
        public const string StudentOverridePayment = "30_student_override_payment";
        public const string StudentMoneyChargeBack = "32_student_money_charge_back";

        //coupon
        public const string CouponSearch = "33_coupon_search";
        public const string CouponAddEdit = "34_coupon_add_edit";
        public const string CouponDelete = "35_coupon_delete";

        //parameter
        public const string ParameterAddEdit = "31_parameter_add_edit";
        public const string ParameterDelete = "36_parameter_delete";

        //order actions
        public const string OrderSearch = "37_order_search";
        public const string OrderCreateExternalLink = "52_external_link_create";

        //notification actions
        public const string NotificationDelete = "41_notification_delete";
        public const string NotificationUpdateStatus = "42_notification_stasus_update";
        public const string NotificationActionHistory = "43_notification_action_history";

        //product
        public const string ProductSearch = "49_product_search";
        public const string ProductAddEdit = "50_product_add_edit";
        public const string ProductDelete = "51_product_delete";

        //profile filter
        public const string ProfileFilterAddEdit = "55_profile_filter_add_edit";
        public const string ProfileFilterDelete = "56_profile_filter_delete";

        //admin staff
        public const string StaffAddEdit = "57_staff_add_edit";
        public const string StaffResetPasswordMail = "58_staff_reset_pass_mail";
    }

    public static class UserLoginProvider
    {
        public const string TwoFactorAuth = "2FA";
    }

    public static class UserLoginName
    {
        public const string TwoFactorAuth = "Two Factor Auth";
    }

    public static class DefaultAuthenticationTypes
    {
        public const string ApplicationCookie = "ApplicationCookie";
        public const string ExternalCookie = "ExternalCookie";
    }

    public static class ApiRequest
    {
        public const string ApplicationCookie = "ApplicationCookie";
        public const string ExternalCookie = "ExternalCookie";
    }

    public static class ChannelType
    {
        public const string Ios = "0";
        public const string Android = "1";
        public const string WebApp = "2";
        public const string AdminPanel = "3";
    }

    /// <summary>
    /// dbo.[FileType] table Ids
    /// </summary>
    public static class FileType
    {
        public const string Document = "080ED682-24D2-4F0E-B746-5000B9F239DA";
        public const string Resume = "815A889F-C550-41B9-AA26-6810C129F0BA";
        public const string ReferenceLetter = "4C20BC71-C876-4AC3-8483-76B9C979178A";
        public const string CertificationLicense = "F4C5714A-B4BF-4C58-867D-7737C77E278C";
        public const string Degree = "37C819C8-2AE0-48B3-9FC3-84BE5D12594E";
        public const string Identity = "23E5D5B7-E16E-4443-8B55-861E924C1A61";
        public const string Citizenship = "C89ADE64-93D0-4AE4-AD4A-BC0433604F10";
        public const string Transcript = "926E01BA-856D-4508-B0EF-DEF7AF707788";
        public const string Essay = "89225B48-84D7-4B2C-9E75-FF9CFA960B9F";
        public const string TestScore = "91328598-EAF5-4177-B223-694DF50C9C30";
    }


    #region image paths

    public static class ImagePath
    {
        public const string Category = "content/media/category/";
        public const string User = "content/media/user/";
        public const string UserDefault = "content/media/user/avatar.png";
    }

    #endregion image path

    #region UserMessageTypes

    public static class UserMessageType
    {
        public const string None = "none";
        public const string ServerError = "server-error";
        public const string Error = "error";
        public const string Warning = "warning";
        public const string Success = "success";
        public const string Info = "info";
    }

    #endregion  UserMessageTypes

    #region RequestType

    public static class RequestTypeText
    {
        public const string Complaint = "sikayet";
        public const string Suggession = "Öneri";
        public const string Wish = "İstek";
        public const string Other = "Diğer";
    }

    #endregion RequestType


    #region cookies

    public static class Cookies
    {
        public const string AccessToken = "AccessToken";
    }

    #endregion cookies

    #region cahce keys

    public static class CacheKey
    {
        public const string ActiveCampaigns = "active_campaigns";

        public const string GetCertificates = "get_certificates";

        public const string GetPositions = "get_positions";
    }

    #endregion cahce keys

    #region request headers

    public static class RequestHeader
    {
        public const string Authorization = "Authorization";
        public const string ApiKey = "ApiKey";
        //public const string JobApiKey = "JobApiKey";
        public const string ChannelType = "ChannelType";
        public const string SessionKey = "SessionKey";
        public const string PfeUserId = "PfeUserId";
        public const string PfeUserTeacherRole = "PfeUserTeacherRole";
        public const string PfeUserNameSurname = "PfeUserNameSurname";
        public const string NewPassword = "NewPwd";
    }

    #endregion request headers

    #region database Ids

    /// <summary>
    /// includes db related special keys or ids
    /// </summary>
    public static class DatabaseKey
    {
        public static class ApplicationRoleId
        {
            public const string Admin = "ede64fc4-7b30-45f7-b92d-e71f3d0027b6";
            public const string Owner = "911f5c44-c2d1-43aa-9247-ec71fbc17956";
        }

        /// <summary>
        /// dbo.Order.[OrderStatus] table Ids
        /// </summary>
        public static class OrderStatus
        {
            public const string Confirmed = "6F3206D7-5BE4-4EE0-8B29-02FF02CCA8DE";
            /// <summary>
            /// Refunded or Returned are the same
            /// </summary>
            public const string Returned = "C8F3BBCF-18DE-446B-940D-5F654C9B82EB";
            /// <summary>
            /// initial, pending or waiting
            /// </summary>
            public const string Waiting = "64781E6A-5680-47ED-BAA2-A632A7FD3427";
            public const string Canceled = "F800BA12-B7A4-44A1-9435-ACD6E0C031F0";
            public const string WaitingForWireTransferApproval = "41F33BB9-7737-47CB-8F64-F4C8075C2CDA";
            public const string Rejected = "974B19F2-17EF-400F-9B35-D22066A0D709";
            /// <summary>
            /// This status added after Stripe integration.
            /// Once the user completes purchase Stripe sends us a webHook for confirmation.
            /// Once we get the webhook, we flag the order as ApprovedByStripe
            /// </summary>
            public const string ApprovedByStripe = "F160C529-15B9-4200-B5B2-B93EAFF4EFA2";
        }

        public static class Setting
        {
            public const int NotifyOnPriceChanges = 1;

            public const int NotifyOnPriceDecreased = 2;

            public const int NotifyOnPriceIncreased = 3;

            public const int NotifyOnExactPrice = 4;

            public const int NotifyOnQuantityChanges = 5;

            public const int NotifyOnQuantityDecreased = 6;

            public const int NotifyOnQuantityIncreased = 7;

            public const int NotifyOnExactQuantity = 8;
        }

        /// <summary>
        /// job names in db
        /// </summary>
        public static class JobName
        {
            public const string ProductPropertyRefresher = "ProductPropertyRefresher";
        }

        /// <summary>
        /// product plan ids
        /// </summary>
        public static class ProductId
        {
            /// <summary>
            /// not selected or any type of plan
            /// </summary>
            public const string Any = "ANY";
            /// <summary>
            /// free plan
            /// </summary>
            public const string Free = "3DD39319-4667-40AF-97C2-2DB760262483";
            /// <summary>
            /// core plan
            /// </summary>
            public const string Core = "63894E11-641B-40FD-A5A8-00E1CFD40C0F";
            /// <summary>
            /// plus plan
            /// </summary>
            public const string Plus = "FF2FEE06-C231-445C-B6D5-474A079D578C";
            /// <summary>
            /// advance plan
            /// </summary>
            public const string Advance = "FC41137F-1FC4-4D85-BB0A-D389A0E84821";

            /// <summary>
            /// canada program book your seat payment
            /// </summary>
            public const string BookingSeat = "5E5FCA8C-A072-4973-BB09-A92959DA19E4";

            /// <summary>
            /// canada training program remaining fee
            /// </summary>
            public const string CanadaTrainingProgramFee = "A1AC0887-E033-4F52-81E3-D65859B11577";

            /// <summary>
            /// Application Processing Fee ($95 non-refundable)
            /// </summary>
            public const string ApplicationFee = "65D4FDFE-D802-41F7-886D-87AE96A1EC21";

            /// <summary>
            /// $1000 Deposit Fee Payment
            /// </summary>
            public const string DepositFee = "8BF7A044-6299-4BC5-A38B-200179AEE84B";

            /// <summary>
            /// wiretransfer payment product id
            /// </summary>
            public const string WireTransfer = "C607443F-742F-4820-B615-6A658A3479B1";
        }

        /// <summary>
        /// user role ids
        /// </summary>
        public static class UserRoleId
        {
            /// <summary>
            /// any users
            /// </summary>
            public const string Any = "ANY";
            /// <summary>
            /// school user role id
            /// </summary>
            public const string School = "CB924E27-5243-4049-A202-1DCE7A8702C8";
            /// <summary>
            /// teacher user role id
            /// </summary>
            public const string Teacher = "2E5794BD-3701-471C-9EE2-4685F71E8A19";

            /// <summary>
            /// student user role Id
            /// </summary>
            public const string Student = "BF125D54-BF54-41E1-9B21-06455D6B31C1";
        }

        /// <summary>
        /// ParameterType.Id constants
        /// </summary>
        public static class ParameterType
        {
            /// <summary>
            /// Zero type means all parameters
            /// </summary>
            public const int All = 0;

            /// <summary>
            /// Qualifications parameters
            /// </summary>
            public const int Qualification = 1;

            /// <summary>
            /// who will pay for the tution or room
            /// </summary>
            public const int Buyer = 2;

            /// <summary>
            /// MajorFields parameters
            /// </summary>
            public const int MajorField = 3;

            /// <summary>
            /// start date selection parameters
            /// </summary>
            public const int ApplicationStartDate = 4;

            /// <summary>
            /// FluencyInTurkish parameters
            /// </summary>
            public const int FluencyInTurkish = 5;

            /// <summary>
            /// app status texts parameters
            /// </summary>
            public const int ApplicationStatus = 6;

            /// <summary>
            /// app status information text parameters
            /// </summary>
            public const int ApplicationStatusInfoText = 7;

            /// <summary>
            /// email template parameters
            /// </summary>
            public const int StudentEmailTemplate = 8;

            /// <summary>
            /// MajorFieldsVocational parameters
            /// </summary>
            public const int MajorFieldVocational = 9;

            /// <summary>
            /// MajorFieldsBachelor parameters
            /// </summary>
            public const int MajorFieldBachelor = 10;

            /// <summary>
            /// MajorFieldsMaster parameters
            /// </summary>
            public const int MajorFieldMaster = 11;

            /// <summary>
            /// MajorFieldsHighSchool parameters
            /// </summary>
            public const int MajorFieldHighSchool = 12;

            /// <summary>
            /// MajorFieldsPhD parameters
            /// </summary>
            public const int MajorFieldPhD = 13;

            /// <summary>
            /// SmsSenderText parameters
            /// </summary>
            public const int SmsSenderText = 14;

            /// <summary>
            /// SmsBodyText parameters
            /// </summary>
            public const int SmsBodyText = 15;

            /// <summary>
            /// Coupon.Type parameters
            /// </summary>
            public const int CouponType = 16;

            /// <summary>
            /// teacher email template parameters
            /// </summary>
            public const int TeacherEmailTemplate = 17;

            /// <summary>
            /// initial, 500$ paid, Profile completed, 3000$ paid, etc..
            /// </summary>
            public const int CanadaProgramStatus = 18;

            /// <summary>
            /// canada 3 week, canada 4 week, etc..
            /// </summary>
            public const int UserProgramName = 19;
        }

        /// <summary>
        /// PparameterGroup.Id constants
        /// </summary>
        public static class ParameterGroup
        {
            public const int All = 0;
            public const int Scholarship = 1;
            public const int EmailTemplate = 2;
            public const int Sms = 3;
            public const int Coupon = 4;
            public const int UserProgram = 5;
            public const int ProfileAdditionalInfo = 6;
        }
    }

    #endregion database Ids
}



