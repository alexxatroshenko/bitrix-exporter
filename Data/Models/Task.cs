using System.Text.Json.Serialization;

namespace Data.Models;

public class Task
{
    public List<Task> ChildTasks { get; set; } = [];
    public List<Comment> Comments { get; set; } = [];
    public List<AttachedFile> AttachedFiles { get; set; } = [];
    
    [JsonPropertyName("TITLE")]
    public string Title { get; set; } = null!;
    
    [JsonPropertyName("STAGE_ID")]
    public int StageId { get; set; }
    
    [JsonPropertyName("DESCRIPTION")]
    public string Description { get; set; } = null!;
    
    [JsonPropertyName("DEADLINE")]
    public string Deadline { get; set; } = null!;

    [JsonPropertyName("START_DATE_PLAN")]
    public string StartDatePlan { get; set; } = null!;

    [JsonPropertyName("END_DATE_PLAN")]
    public string EndDatePlan { get; set; } = null!;

    [JsonPropertyName("PRIORITY")]
    public int Priority { get; set; }
    
    [JsonPropertyName("ALLOW_CHANGE_DEADLINE")]
    public string AllowChangeDeadLine { get; set; } = null!;
    
    [JsonPropertyName("TASK_CONTROL")]
    public string TaskControl { get; set; } = null!;
    
    [JsonPropertyName("PARENT_ID")]
    public int ParentId { get; set; }
    
    [JsonPropertyName("GROUP_ID")]
    public int GroupId { get; set; }
    
    [JsonPropertyName("RESPONSIBLE_ID")]
    public int ResponsibleId { get; set; }
    
    [JsonPropertyName("TIME_ESTIMATE")]
    public string TimeEstimate { get; set; } = null!;
    
    [JsonPropertyName("ID")]
    public int Id { get; set; }
    
    [JsonPropertyName("CREATED_BY")]
    public int CreatedBy { get; set; }
    
    [JsonPropertyName("DESCRIPTION_IN_BBCODE")]
    public string DescriptionInBbcode { get; set; } = null!;
    
    [JsonPropertyName("DECLINE_REASON")]
    public string DeclineReason { get; set; } = null!;

    [JsonPropertyName("REAL_STATUS")]
    public string RealStatus { get; set; } = null!;

    [JsonPropertyName("STATUS")]
    public string Status { get; set; } = null!;

    [JsonPropertyName("RESPONSIBLE_NAME")]
    public string ResponsibleName { get; set; } = null!;

    [JsonPropertyName("RESPONSIBLE_LAST_NAME")]
    public string ResponsibleLastName { get; set; } = null!;

    [JsonPropertyName("RESPONSIBLE_SECOND_NAME")]
    public string ResponsibleSecondName { get; set; } = null!;

    [JsonPropertyName("DATE_START")]
    public DateTime DateStart { get; set; }
    
    [JsonPropertyName("DURATION_FACT")]
    public int? DurationFact { get; set; }
    
    [JsonPropertyName("DURATION_PLAN")]
    public string DurationPlan { get; set; } = null!;

    [JsonPropertyName("DURATION_TYPE")]
    public string DurationType { get; set; } = null!;

    [JsonPropertyName("CREATED_BY_NAME")]
    public string CreatedByName { get; set; } = null!;

    [JsonPropertyName("CREATED_BY_LAST_NAME")]
    public string CreatedByLastName { get; set; } = null!;

    [JsonPropertyName("CREATED_BY_SECOND_NAME")]
    public string CreatedBySecondName { get; set; } = null!;

    [JsonPropertyName("CREATED_DATE")]
    public string CreatedDate { get; set; } = null!;

    [JsonPropertyName("CHANGED_BY")]
    public string ChangedBy { get; set; } = null!;

    [JsonPropertyName("CHANGED_DATE")]
    public string ChangedDate { get; set; } = null!;

    [JsonPropertyName("STATUS_CHANGED_BY")]
    public string StatusChangedBy { get; set; } = null!;

    [JsonPropertyName("STATUS_CHANGED_DATE")]
    public string StatusChangedDate { get; set; } = null!;

    [JsonPropertyName("CLOSED_BY")]
    public string ClosedBy { get; set; } = null!;

    [JsonPropertyName("CLOSED_DATE")]
    public string ClosedDate { get; set; } = null!;

    [JsonPropertyName("ACTIVITY_DATE")]
    public string ActivityDate { get; set; } = null!;

    [JsonPropertyName("GUID")]
    public string Guid { get; set; } = null!;

    [JsonPropertyName("MARK")]
    public int? Mark { get; set; }
    
    [JsonPropertyName("VIEWED_DATE")]
    public string ViewedDate { get; set; } = null!;

    [JsonPropertyName("TIME_SPENT_IN_LOGS")]
    public int? TimeSpentInLogs { get; set; }
    
    [JsonPropertyName("FAVORITE")]
    public string Favorite { get; set; } = null!;

    [JsonPropertyName("ALLOW_TIME_TRACKING")]
    public string AllowTimeTracking { get; set; } = null!;

    [JsonPropertyName("MATCH_WORK_TIME")]
    public string MatchWorkTime { get; set; } = null!;

    [JsonPropertyName("ADD_IN_REPORT")]
    public string AddInReport { get; set; } = null!;

    [JsonPropertyName("FORUM_ID")]
    public string ForumId { get; set; } = null!;

    [JsonPropertyName("FORUM_TOPIC_ID")]
    public string ForumTopicId { get; set; } = null!;

    [JsonPropertyName("COMMENTS_COUNT")]
    public string CommentsCount { get; set; } = null!;

    [JsonPropertyName("SITE_ID")]
    public string SiteId { get; set; } = null!;

    [JsonPropertyName("SUBORDINATE")]
    public string Subordinate { get; set; } = null!;

    [JsonPropertyName("FORKED_BY_TEMPLATE_ID")]
    public int? ForkedByTemplateId { get; set; }
    
    [JsonPropertyName("MULTITASK")]
    public string Multitask { get; set; } = null!;

    [JsonPropertyName("SCENARIO_NAME")]
    public string ScenarioName { get; set; } = null!;

    [JsonPropertyName("IS_REGULAR")]
    public string IsRegular { get; set; } = null!;

    [JsonPropertyName("FLOW_ID")]
    public int? FlowId { get; set; }
    
}