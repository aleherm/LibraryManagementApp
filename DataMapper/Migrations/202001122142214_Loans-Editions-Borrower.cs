namespace DataMapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoansEditionsBorrower : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LoanBooks", "Loan_Id", "dbo.Loans");
            DropForeignKey("dbo.LoanBooks", "Book_Id", "dbo.Books");
            DropIndex("dbo.LoanBooks", new[] { "Loan_Id" });
            DropIndex("dbo.LoanBooks", new[] { "Book_Id" });
            CreateTable(
                "dbo.LoanEditions",
                c => new
                    {
                        Loan_Id = c.Int(nullable: false),
                        Edition_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Loan_Id, t.Edition_Id })
                .ForeignKey("dbo.Loans", t => t.Loan_Id, cascadeDelete: true)
                .ForeignKey("dbo.Editions", t => t.Edition_Id, cascadeDelete: true)
                .Index(t => t.Loan_Id)
                .Index(t => t.Edition_Id);
            
            DropTable("dbo.LoanBooks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LoanBooks",
                c => new
                    {
                        Loan_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Loan_Id, t.Book_Id });
            
            DropForeignKey("dbo.LoanEditions", "Edition_Id", "dbo.Editions");
            DropForeignKey("dbo.LoanEditions", "Loan_Id", "dbo.Loans");
            DropIndex("dbo.LoanEditions", new[] { "Edition_Id" });
            DropIndex("dbo.LoanEditions", new[] { "Loan_Id" });
            DropTable("dbo.LoanEditions");
            CreateIndex("dbo.LoanBooks", "Book_Id");
            CreateIndex("dbo.LoanBooks", "Loan_Id");
            AddForeignKey("dbo.LoanBooks", "Book_Id", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoanBooks", "Loan_Id", "dbo.Loans", "Id", cascadeDelete: true);
        }
    }
}
