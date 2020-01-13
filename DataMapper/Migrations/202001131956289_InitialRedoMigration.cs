namespace DataMapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialRedoMigration : DbMigration
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
                        DateOfBirth = c.DateTime(),
                        DateOfDeath = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Domains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DomainName = c.String(nullable: false, maxLength: 100),
                        ParentDomain_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Domains", t => t.ParentDomain_Id)
                .Index(t => t.ParentDomain_Id);
            
            CreateTable(
                "dbo.Editions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookType = c.Int(nullable: false),
                        PageNumber = c.Int(nullable: false),
                        Year = c.Int(),
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
                "dbo.Loans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(),
                        Borrower_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Borrowers", t => t.Borrower_Id)
                .Index(t => t.Borrower_Id);
            
            CreateTable(
                "dbo.Borrowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(),
                        ReaderFlg = c.Boolean(nullable: false),
                        LibrarianFlg = c.Boolean(nullable: false),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        Author_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_Id, t.Author_Id })
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.Author_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.DomainBooks",
                c => new
                    {
                        Domain_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Domain_Id, t.Book_Id })
                .ForeignKey("dbo.Domains", t => t.Domain_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Domain_Id)
                .Index(t => t.Book_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "Borrower_Id", "dbo.Borrowers");
            DropForeignKey("dbo.Borrowers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Editions", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.LoanEditions", "Edition_Id", "dbo.Editions");
            DropForeignKey("dbo.LoanEditions", "Loan_Id", "dbo.Loans");
            DropForeignKey("dbo.Domains", "ParentDomain_Id", "dbo.Domains");
            DropForeignKey("dbo.DomainBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.DomainBooks", "Domain_Id", "dbo.Domains");
            DropForeignKey("dbo.BookAuthors", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books");
            DropIndex("dbo.LoanEditions", new[] { "Edition_Id" });
            DropIndex("dbo.LoanEditions", new[] { "Loan_Id" });
            DropIndex("dbo.DomainBooks", new[] { "Book_Id" });
            DropIndex("dbo.DomainBooks", new[] { "Domain_Id" });
            DropIndex("dbo.BookAuthors", new[] { "Author_Id" });
            DropIndex("dbo.BookAuthors", new[] { "Book_Id" });
            DropIndex("dbo.Borrowers", new[] { "Address_Id" });
            DropIndex("dbo.Loans", new[] { "Borrower_Id" });
            DropIndex("dbo.Editions", new[] { "Book_Id" });
            DropIndex("dbo.Domains", new[] { "ParentDomain_Id" });
            DropTable("dbo.LoanEditions");
            DropTable("dbo.DomainBooks");
            DropTable("dbo.BookAuthors");
            DropTable("dbo.Borrowers");
            DropTable("dbo.Loans");
            DropTable("dbo.Editions");
            DropTable("dbo.Domains");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
            DropTable("dbo.Addresses");
        }
    }
}
