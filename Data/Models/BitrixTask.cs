using Newtonsoft.Json;

namespace Data.Models;

public class TasksResponse
{
    [JsonProperty("result")]
    public List<BitrixTask> Result { get; set; } = [];
    
    [JsonProperty("total")]
    public int Total { get; set; }

    [JsonIgnore] 
    public int Time { get; set; }
}
public class BitrixTask
{
    [JsonIgnore]
    public List<BitrixTask> ChildTasks { get; set; } = [];
    
    public List<Comment> Comments { get; set; } = [];
    
    [JsonProperty("TITLE")]
    public string Title { get; set; } = null!;

    [JsonProperty("STAGE_ID")] 
    public string StageId { get; set; } = null!;
    
    [JsonProperty("DESCRIPTION")]
    public string Description { get; set; } = null!;
    
    [JsonProperty("DEADLINE")]
    public string Deadline { get; set; } = null!;

    [JsonProperty("START_DATE_PLAN")]
    public string StartDatePlan { get; set; } = null!;

    [JsonProperty("END_DATE_PLAN")]
    public string EndDatePlan { get; set; } = null!;

    [JsonProperty("PRIORITY")] 
    public string Priority { get; set; } = null!;
    
    [JsonProperty("ALLOW_CHANGE_DEADLINE")]
    public string AllowChangeDeadLine { get; set; } = null!;
    
    [JsonProperty("TASK_CONTROL")]
    public string TaskControl { get; set; } = null!;

    [JsonProperty("PARENT_ID")]
    public int? ParentId { get; set; }

    [JsonProperty("GROUP_ID")]
    public string GroupId { get; set; } = null!;
    
    [JsonProperty("RESPONSIBLE_ID")]
    public string ResponsibleId { get; set; } = null!;
    
    [JsonProperty("TIME_ESTIMATE")]
    public string TimeEstimate { get; set; } = null!;

    [JsonProperty("ID")]
    public int Id { get; set; }

    [JsonProperty("CREATED_BY")] 
    public string CreatedBy { get; set; } = null!;
    
    [JsonProperty("DESCRIPTION_IN_BBCODE")]
    public string DescriptionInBbcode { get; set; } = null!;
    
    [JsonProperty("DECLINE_REASON")]
    public string DeclineReason { get; set; } = null!;

    [JsonProperty("REAL_STATUS")]
    public string RealStatus { get; set; } = null!;

    [JsonProperty("STATUS")]
    public string Status { get; set; } = null!;

    [JsonProperty("RESPONSIBLE_NAME")]
    public string ResponsibleName { get; set; } = null!;

    [JsonProperty("RESPONSIBLE_LAST_NAME")]
    public string ResponsibleLastName { get; set; } = null!;

    [JsonProperty("RESPONSIBLE_SECOND_NAME")]
    public string ResponsibleSecondName { get; set; } = null!;

    [JsonProperty("DATE_START")] 
    public string DateStart { get; set; } = null!;
    
    [JsonProperty("DURATION_FACT")]
    public int? DurationFact { get; set; }
    
    [JsonProperty("DURATION_PLAN")]
    public string DurationPlan { get; set; } = null!;

    [JsonProperty("DURATION_TYPE")]
    public string DurationType { get; set; } = null!;

    [JsonProperty("CREATED_BY_NAME")]
    public string CreatedByName { get; set; } = null!;

    [JsonProperty("CREATED_BY_LAST_NAME")]
    public string CreatedByLastName { get; set; } = null!;

    [JsonProperty("CREATED_BY_SECOND_NAME")]
    public string CreatedBySecondName { get; set; } = null!;

    [JsonProperty("CREATED_DATE")]
    public string CreatedDate { get; set; } = null!;

    [JsonProperty("CHANGED_BY")]
    public string ChangedBy { get; set; } = null!;

    [JsonProperty("CHANGED_DATE")]
    public string ChangedDate { get; set; } = null!;

    [JsonProperty("STATUS_CHANGED_BY")]
    public string StatusChangedBy { get; set; } = null!;

    [JsonProperty("STATUS_CHANGED_DATE")]
    public string StatusChangedDate { get; set; } = null!;

    [JsonProperty("CLOSED_BY")]
    public string ClosedBy { get; set; } = null!;

    [JsonProperty("CLOSED_DATE")]
    public string ClosedDate { get; set; } = null!;

    [JsonProperty("ACTIVITY_DATE")]
    public string ActivityDate { get; set; } = null!;

    [JsonProperty("GUID")]
    public string Guid { get; set; } = null!;

    [JsonProperty("MARK")]
    public int? Mark { get; set; }
    
    [JsonProperty("VIEWED_DATE")]
    public string ViewedDate { get; set; } = null!;

    [JsonProperty("TIME_SPENT_IN_LOGS")]
    public int? TimeSpentInLogs { get; set; }
    
    [JsonProperty("FAVORITE")]
    public string Favorite { get; set; } = null!;

    [JsonProperty("ALLOW_TIME_TRACKING")]
    public string AllowTimeTracking { get; set; } = null!;

    [JsonProperty("MATCH_WORK_TIME")]
    public string MatchWorkTime { get; set; } = null!;

    [JsonProperty("ADD_IN_REPORT")]
    public string AddInReport { get; set; } = null!;

    [JsonProperty("FORUM_ID")]
    public string ForumId { get; set; } = null!;

    [JsonProperty("FORUM_TOPIC_ID")]
    public string ForumTopicId { get; set; } = null!;

    [JsonProperty("COMMENTS_COUNT")]
    public string CommentsCount { get; set; } = null!;

    [JsonProperty("SITE_ID")]
    public string SiteId { get; set; } = null!;

    [JsonProperty("SUBORDINATE")]
    public string Subordinate { get; set; } = null!;

    [JsonProperty("FORKED_BY_TEMPLATE_ID")]
    public int? ForkedByTemplateId { get; set; }
    
    [JsonProperty("MULTITASK")]
    public string Multitask { get; set; } = null!;

    [JsonProperty("SCENARIO_NAME")]
    public string ScenarioName { get; set; } = null!;

    [JsonProperty("IS_REGULAR")]
    public string IsRegular { get; set; } = null!;

    [JsonProperty("FLOW_ID")]
    public int? FlowId { get; set; }
    
}
