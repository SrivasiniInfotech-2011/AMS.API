namespace AMS.Models.Constants
{
    public class Constants
    {
        public const string APP_SECRET = "wSGnVqSnc@4iNj2Qe^S-8ZnvEHQ-UyGS~y)[;yhJdt'#ox<vG%Mp8Gn{EZyG#Db";
        public const string APP_SCOPE = "amsApiRequestScope";
        public const string APP_CLIENT_ID = "A25A96F4D2E6193E5D28F52176622";
        public static class UserClaim
        {
            public const string Role = "role";
            public const string Admin = "admin";
            public const string User = "user";
            public const string DataEventRecords = "dataEventRecords";
            public const string AdminDataEventRecords = "dataEventRecords.admin";
            public const string UserAdminEventRecords = "dataEventRecords.user";
            public const string ScopeDisplayName = "Scope for the AMS API Resource";
        }
        public static class ApiResource
        {
            public const string Role = "role";
            public const string Admin = "admin";
            public const string User = "user";
            public const string DataEventRecordsApi = "dataEventRecordsApi";
            public const string ApiResourceSecret = "C8EF369FEAD9FF58A847244243A6B";
            public const string DataEventRecordScope = "dataEventRecordsScope";
            public const string ApiResouceDisplayName = "Data Event Records API";
        }
    }
}
