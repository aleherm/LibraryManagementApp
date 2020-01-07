namespace DataMapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false, maxLength: 50),
                        Street = c.String(nullable: false, maxLength: 50),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Language = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateOfDeath = c.DateTime(nullable: false),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Loan_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Loans", t => t.Loan_Id)
                .Index(t => t.Loan_Id);
            
            CreateTable(
                "dbo.Domains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DomainName = c.String(nullable: false, maxLength: 100),
                        ParentDomain_Id = c.Int(),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Domains", t => t.ParentDomain_Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.ParentDomain_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.Editions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageNumber = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        BookType = c.Int(nullable: false),
                        Publisher = c.String(nullable: false, maxLength: 100),
                        NoForLibrary = c.Int(nullable: false),
                        NoForLoan = c.Int(nullable: false),
                        NoTotal = c.Int(nullable: false),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.Borrowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        ReaderFlg = c.Boolean(nullable: false),
                        LibrarianFlg = c.Boolean(nullable: false),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        Borrower_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Borrowers", t => t.Borrower_Id)
                .Index(t => t.Borrower_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "Borrower_Id", "dbo.Borrowers");
            DropForeignKey("dbo.Books", "Loan_Id", "dbo.Loans");
            DropForeignKey("dbo.Borrowers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Editions", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Domains", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Domains", "ParentDomain_Id", "dbo.Domains");
            DropForeignKey("dbo.Authors", "Book_Id", "dbo.Books");
            DropIndex("dbo.Loans", new[] { "Borrower_Id" });
            DropIndex("dbo.Borrowers", new[] { "Address_Id" });
            DropIndex("dbo.Editions", new[] { "Book_Id" });
            DropIndex("dbo.Domains", new[] { "Book_Id" });
            DropIndex("dbo.Domains", new[] { "ParentDomain_Id" });
            DropIndex("dbo.Books", new[] { "Loan_Id" });
            DropIndex("dbo.Authors", new[] { "Book_Id" });
            DropTable("dbo.Loans");
            DropTable("dbo.Borrowers");
            DropTable("dbo.Editions");
            DropTable("dbo.Domains");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
            DropTable("dbo.Addresses");
        }
    }
}
