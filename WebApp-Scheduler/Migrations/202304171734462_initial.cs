namespace WebApp_Scheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProgramId = c.Int(nullable: false),
                        IsHoliday = c.Boolean(nullable: false),
                        IsChanged = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(),
                        CourseName = c.String(),
                        Instructor = c.String(),
                        ContactHours = c.Int(nullable: false),
                        HoursPerDay = c.Int(nullable: false),
                        NumberOfDays = c.Int(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        ScheduleTypeId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScheduleTypes", t => t.ScheduleTypeId, cascadeDelete: true)
                .Index(t => t.ScheduleTypeId);
            
            CreateTable(
                "dbo.ScheduleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayOption = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseWithTimeAllocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProgramId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        CourseName = c.String(),
                        Topic = c.String(),
                        TimeAllocationHelperId = c.Int(nullable: false),
                        AmountOfTeachingHours = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TimeAllocationHelpers", t => t.TimeAllocationHelperId, cascadeDelete: true)
                .Index(t => t.TimeAllocationHelperId);
            
            CreateTable(
                "dbo.TimeAllocationHelpers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProgramId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        RemainingTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PreRequisites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequiredCourseId = c.Int(nullable: false),
                        ActualCourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProgramDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProgramName = c.String(),
                        ProgramStartDate = c.DateTime(),
                        ProgramEndDate = c.DateTime(),
                        TotalTeachingHoursOfDay = c.Int(nullable: false),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScheduleHelperContextDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        courseId = c.Int(nullable: false),
                        CourseName = c.String(),
                        TeachingDays = c.String(),
                        TotalHoursPerDay = c.Int(nullable: false),
                        OverallTotalHours = c.Int(nullable: false),
                        NoOfTeachingDays = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseWithTimeAllocations", "TimeAllocationHelperId", "dbo.TimeAllocationHelpers");
            DropForeignKey("dbo.Courses", "ScheduleTypeId", "dbo.ScheduleTypes");
            DropIndex("dbo.CourseWithTimeAllocations", new[] { "TimeAllocationHelperId" });
            DropIndex("dbo.Courses", new[] { "ScheduleTypeId" });
            DropTable("dbo.Schedules");
            DropTable("dbo.ScheduleHelperContextDatas");
            DropTable("dbo.ProgramDetails");
            DropTable("dbo.PreRequisites");
            DropTable("dbo.TimeAllocationHelpers");
            DropTable("dbo.CourseWithTimeAllocations");
            DropTable("dbo.ScheduleTypes");
            DropTable("dbo.Courses");
            DropTable("dbo.Calendars");
        }
    }
}
