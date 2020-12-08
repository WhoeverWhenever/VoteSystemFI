namespace VoteSystem.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VoteChoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        choiceId = c.Int(nullable: false),
                        Vote_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vote", t => t.Vote_Id)
                .Index(t => t.Vote_Id);
            
            AddColumn("dbo.Poll", "PollStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Poll", "PollEndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Poll", "MutlipleSelection", c => c.Boolean(nullable: false));
            AddColumn("dbo.Vote", "VoteDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Vote", "voteStart");
            DropColumn("dbo.Vote", "voteEnd");
            DropColumn("dbo.Vote", "choiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vote", "choiceId", c => c.Int(nullable: false));
            AddColumn("dbo.Vote", "voteEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vote", "voteStart", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.VoteChoice", "Vote_Id", "dbo.Vote");
            DropIndex("dbo.VoteChoice", new[] { "Vote_Id" });
            DropColumn("dbo.Vote", "VoteDate");
            DropColumn("dbo.Poll", "MutlipleSelection");
            DropColumn("dbo.Poll", "PollEndDate");
            DropColumn("dbo.Poll", "PollStartDate");
            DropTable("dbo.VoteChoice");
        }
    }
}
