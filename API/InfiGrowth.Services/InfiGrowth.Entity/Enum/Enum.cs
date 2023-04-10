namespace InfiGrowth.Entity.Enum
{
    public enum AuditStatus
    {
        Active = 0,
        Implemented = 1,
        Prospect = 2,
        WIP = 3,
        OnHold = 4,
        Pending = 5
    }
    public enum ClientStatus
    {
        Active = 0,
        Lead = 1,
        Prospect = 2,
        Completed = 3,
        AppointmentScheduled = 4,
        QualifiedToBuy = 5,
        PresentationScheduled = 6,
        DecisionMakerBoughtIn = 7,
        ContractSent = 8,
        ClosedWon = 9,
        ClosedLost = 10
    }
    public enum DocHolderTypes
    {
        Client = 0,
        Ticket = 1,
        Audit = 2,
        AuditResponse = 3
    }
    public enum GroupType
    {
        Members = 0,
        Department = 1,
        Role = 2,
        Designation = 3
    }
    public enum ImpactList
    {
        Low = 0,
        Medium = 1,
        High = 2
    }
    public enum MemberStatus
    {
        Active = 0,
        Resigned = 1
    }
    public enum PriorityList
    {
        Low = 0,
        Medium = 1,
        High = 2
    }
    public enum ROIType
    {
        CPC = 0,
        GSC = 1
    }
    public enum UckType
    {
        URL = 0,
        Competitors = 1,
        Keywords = 2
    }
    public enum OperationType
    {
        INSERT = 0,
        UPDATE = 1,
        DELETE = 2
    }
    public enum CompetitionLevel
    {
        LOW = 0,
        HIGH = 1,
        MEDIUM = 2
    }
    public enum UpDown
    {
        UP = 0,
        DOWN = 1
    }
    public enum AuditResponseTypes
    {
        Yes = 0,
        No = 1,
        Not_Applicable = 2
    }
    public enum RefType
    {
        Domain = 0,
        Backlink = 1
    }
    public enum TicketType
    {
        Alert = 0,
        CompetitorAlert = 1,
        ChangeRequest = 2,
        Warning = 3
    }
    public enum TicketModuleType
    {
        Universal = 0,
        SOW = 1,
        AdHoc = 2,
        System = 3,
        PitchDeck = 4
    }
    public enum TicketModuleStatus
    {
        Assigned = 0,
        Overdue = 1,
        ApproachingETA = 2,
        AwaitingApproval = 3,
        Closed = 4
    }
    public enum TicketTimeline
    {
        Tickets_Create = 0,
        Tickets_Update = 1,
        Tickets_Assign = 2,
        Tickets_Conversation = 3,
        Tickets_Attachment = 4,
        Tickets_Notes = 5,
        Tickets_View = 6
    }
    public enum ViewTicket
    {
        AllTickets = 0,
        ClientTickets = 1,
        InternalTickets = 2
    }
    public enum TicketStatus
    {
        Open = 0,
        InProgress = 1,
        Resolved = 2,
        Reopened = 3,
        Closed = 4,
        Overdue = 5
    }
    public enum SowStatus
    {
        InProgress = 0,
        AwaitingForApproval = 1
    }
    
    public enum ActivityType
    {
        OffPage = 0,
        OnPage = 1,
        Reports = 2
    }
    public enum CommList
    {
        Call = 0,
        Email = 1,
        Contact = 2
    }

    public enum OrgStatus
    {
        Active = 0,
        Inactive = 1
    }
    public enum AuthenticationType
    {
        Custom = 0,
        Google = 1
    }
    public enum ConfigType
    {
        Available = 0,
        NotAvailable = 1
    }
    public enum Colors
    {
        Yellow,
        Orage,
        Red,
        Green,
        Blue,
        Purple,
        Black
    }
}
