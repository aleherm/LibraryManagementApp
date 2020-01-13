using DomainModel;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LibraryManagementApp
{
    /// <summary>
    /// A helper class for the menu shown in the console user interface.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1101", Justification = "In .NET this is rarely used.")]
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1600", Justification = "No documentantion needed yet.")]
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1124", Justification = "No regions.")]
    public class MenuHelper
    {
        /// <summary>
        /// The input option given by the user.
        /// </summary>
        private int option;

        /// <summary>
        /// The dinamic list of the menu displaied in the console.
        /// </summary>
        private Dictionary<int, string> menu;

        #region [ Show Menu methods ]

        /// <summary>
        /// Shows the menu based on the type.
        /// </summary>
        /// <param name="menuType"></param>
        private void ShowMenu(EMenuType menuType)
        {
            menu = new Dictionary<int, string>();
            
            switch (menuType)
            {
                case EMenuType.EMainMenu:
                    Clear();
                    Console.WriteLine(@" _       ___   ____    ____       _      ____   __   __");
                    Console.WriteLine(@"| |     |_ _| | __ )  |  _ \     / \    |  _ \  \ \ / /");
                    Console.WriteLine(@"| |      | |  |  _ \  | |_) |   / _ \   | |_) |  \ V / ");
                    Console.WriteLine(@"| |___   | |  | |_) | |  _ <   / ___ \  |  _ <    | |  ");
                    Console.WriteLine(@"|_____| |___| |____/  |_| \_\ /_/   \_\ |_| \_\   |_|  by Alexandra Hermeneanu");
                    Console.WriteLine();

                    Console.WriteLine("Type an option!");
                    menu.Add(1, MenuOutput.AuthorMenuItem);
                    menu.Add(2, MenuOutput.BookMenuItem);
                    menu.Add(3, MenuOutput.BorrowerMenuItem);
                    menu.Add(4, MenuOutput.DomainMenuItem);
                    menu.Add(5, MenuOutput.EditionMenuItem);
                    menu.Add(6, MenuOutput.LoanMenuItem);
                    break;
                case EMenuType.EAuthorMenu:
                    menu.Add(1, MenuOutput.AddNew);
                    menu.Add(2, MenuOutput.AuthorEdit);
                    menu.Add(3, MenuOutput.AuthorDelete);
                    menu.Add(4, MenuOutput.AuthorShowAll);
                    menu.Add(8, MenuOutput.Back);
                    break;
                case EMenuType.EBookMenu:
                    menu.Add(1, MenuOutput.AddNew);
                    menu.Add(2, MenuOutput.BookEdit);
                    menu.Add(3, MenuOutput.BookDelete);
                    menu.Add(4, MenuOutput.BookShowAll);
                    menu.Add(5, MenuOutput.BookShowAllForLibrary);
                    menu.Add(6, MenuOutput.BookShowAllForLoan);
                    menu.Add(7, MenuOutput.BookSearch);
                    menu.Add(8, MenuOutput.Back);
                    break;

                case EMenuType.EBorrowerMenu:
                    menu.Add(1, MenuOutput.AddNew);
                    menu.Add(2, MenuOutput.BorrowerEdit);
                    menu.Add(3, MenuOutput.BorrowerDelete);
                    menu.Add(4, MenuOutput.BorrowerShowAll);
                    menu.Add(5, MenuOutput.Back);
                    break;
                case EMenuType.EBookAuthorMenu:
                    menu.Add(1, MenuOutput.AddNewAuthor);
                    menu.Add(2, MenuOutput.AddExistingAuthor);
                    menu.Add(3, MenuOutput.Back);
                    break;
                case EMenuType.EDomainMenu:
                    Console.WriteLine("Not implemented.................");
                    break;
                case EMenuType.EEditionMenu:
                    menu.Add(1, MenuOutput.AddNew);
                    menu.Add(2, MenuOutput.EditionEdit);
                    menu.Add(3, MenuOutput.EditionDelete);
                    menu.Add(4, MenuOutput.EditionShowAll);
                    menu.Add(5, MenuOutput.Back);
                    break;
                default:
                    Console.WriteLine("ERROR 404! Page not found!");
                    break;
            }

            foreach(var pair in menu)
            {
                int key = pair.Key;
                string menuItem = pair.Value;
                Console.WriteLine(key + ". " + menuItem);
            }
        }

        /// <summary>
        /// Displays the MainMenu dashboard and asks the user for an action choice.
        /// </summary>
        public void ShowMainMenu()
        {
            ShowMenu(EMenuType.EMainMenu);

            string input = Console.ReadLine();

            while (!int.TryParse(input, out option))
            {
                Console.WriteLine(MenuErrors.WrongInputFormatError + MenuOutput.TryAgain);
            }

            MainMenuProcessing(option);
        }


        /// <summary>
        /// Displays the AuthorMenu dashboard and asks the user for an action choice
        /// </summary>
        private void ShowAuthorMenu()
        {
            Console.WriteLine(MenuOutput.AuthorMenuTitle);
            ShowMenu(EMenuType.EAuthorMenu);

            string input = Console.ReadLine();

            while (!int.TryParse(input, out option))
            {
                Console.WriteLine(MenuErrors.WrongInputFormatError + MenuOutput.TryAgain);
            }

            AuthorMenuProcessing(option);
        }

        /// <summary>
        /// Displays the BorrowerMenu dashboard and asks the user for an action choice.
        /// </summary>
        public void ShowBorrowerMenu()
        {
            Console.WriteLine(MenuOutput.BorrowerMenuTitle);
            ShowMenu(EMenuType.EBorrowerMenu);

            string input = Console.ReadLine();

            while (!int.TryParse(input, out option))
            {
                Console.WriteLine(MenuErrors.WrongInputFormatError + MenuOutput.TryAgain);
            }

            BorrowerMenuProcessing(option);
        }

        /// <summary>
        ///  Displays the BookMenu dashboard and asks the user for an action choice.
        /// </summary>
        public void ShowBookMenu()
        {
            Console.WriteLine(MenuOutput.BookMenuTitle);
            ShowMenu(EMenuType.EBookMenu);

            string input = Console.ReadLine();

            while (!int.TryParse(input, out option))
            {
                Console.WriteLine(MenuErrors.WrongInputFormatError + MenuOutput.TryAgain);
            }

            BookMenuProcessing(option);
        }

        /// <summary>
        /// Displays the EditionMenu dashboard and asks the user for an action choise.
        /// </summary>
        public void ShowEditionMenu()
        {
            Console.WriteLine(MenuOutput.BookMenuTitle);
            ShowMenu(EMenuType.EEditionMenu);

            string input = Console.ReadLine();

            while (!int.TryParse(input, out option))
            {
                Console.WriteLine(MenuErrors.WrongInputFormatError + MenuOutput.TryAgain);
            }

            //EditionMenuProcessing(option);
        }

        #endregion

        #region [ Menu Processing methods ]

        /// <summary>
        /// Processes the basic actions based on the user's choice.
        /// </summary>
        /// <param name="option"></param>
        public void MainMenuProcessing(int option)
        {
            switch (option)
            {
                case 1:
                    ShowAuthorMenu();
                    break;
                case 2:
                    ShowBookMenu();
                    break;
                case 3:
                    ShowBorrowerMenu();
                    break;
                case 4:
                    //ShowDomainMenu();
                    break;
                case 5:
                    //ShowEditionMenu();
                    break;
                case 6:
                    //ShowLoanMenu();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Processes the Author actions based on user's choice
        /// </summary>
        /// <param name="option"></param>
        private void AuthorMenuProcessing(int option)
        {
            BookAuthorMenuProcessing(option);
        }

        /// <summary>
        /// Processes the Borrower actions based on the user's choice.
        /// </summary>
        /// <param name="option"></param>
        public void BorrowerMenuProcessing(int option)
        {
            BorrowerService borrowerService = new BorrowerService();

            switch (option)
            {
                case 1:
                    Console.WriteLine(MenuOutput.BorrowerEntries);

                    Console.Write(MenuOutput.BorrowerFirstName);
                    string firstName = Console.ReadLine();

                    Console.Write(MenuOutput.BorrowerLastName);
                    string lastName = Console.ReadLine();

                    Console.Write(MenuOutput.BorrowerEmail);
                    string email = Console.ReadLine();

                    Console.Write(MenuOutput.BorrowerDOB);
                    string dob = Console.ReadLine();
                    DateTime? dateOfBirth = DateHelper.ConvertStringToDate(dob);

                    while(dateOfBirth == null)
                    {
                        Console.WriteLine(MenuErrors.WrongInputFormatError + MenuOutput.TryAgain);
                        dob = Console.ReadLine();
                        dateOfBirth = DateHelper.ConvertStringToDate(dob);
                    }

                    Console.Write(MenuOutput.BorrowerAddressCity);
                    string city = Console.ReadLine();

                    Console.Write(MenuOutput.BorrowerAddressStreet);
                    string street = Console.ReadLine();

                    Console.Write(MenuOutput.BorrowerAddressNumber);
                    int number;
                    while(!int.TryParse(Console.ReadLine(), out number))
                    {
                        Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                    }

                    Console.WriteLine(MenuOutput.BorrowerReader);
                    string input = Console.ReadLine().ToUpper();
                    bool readerFlg;

                    switch(input)
                    {
                        case "YES":
                        case "Y":
                            readerFlg = true;
                            break;
                        case "NO":
                        case "N":
                            readerFlg = false;
                            break;
                        default:
                            Console.WriteLine(MenuErrors.InvalidInputError);
                            readerFlg = false;
                            break;
                    }

                    Console.WriteLine(MenuOutput.BorrowerLibrarian);
                    input = Console.ReadLine().ToUpper();
                    bool librarianFlg;

                    switch (input)
                    {
                        case "YES":
                        case "Y":
                            librarianFlg = true;
                            break;
                        case "NO":
                        case "N":
                            librarianFlg = false;
                            break;
                        default:
                            Console.WriteLine(MenuErrors.InvalidInputError);
                            librarianFlg = false;
                            break;
                    }

                    Address address = new Address(city, street, number);

                    Borrower newBorrower = new Borrower(firstName, lastName, email, dateOfBirth, address, readerFlg, librarianFlg);


                    bool isInsertSuccessful = borrowerService.AddNewBorrower(newBorrower);

                    if(isInsertSuccessful)
                    {
                        ShowSuccessMessage(MenuSuccess.BorrowerAddSuccess);
                    }
                    else
                    {
                        ShowErrorMessage(MenuErrors.FailedBorrowerInsert);
                    }

                    ShowBorrowerMenu();
                    break;
                case 2:
                    // TODO: EditBorrower()
                    Console.WriteLine("EditBorrower()");
                    break;
                case 3:
                    // TODO: DeleteBorrower()
                    Console.WriteLine("DeleteBorrower()");
                    break;
                case 4:
                    var borrowers = borrowerService.GetAllBorrowers();
                    foreach (var borrower in borrowers)
                    {
                        Console.WriteLine(borrower.ToString());
                    }
                    break;
                case 5:
                    ShowMenu(EMenuType.EMainMenu);
                    break;
                default:
                    Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                    break;
            }
        }

        /// <summary>
        /// Processes the Author for a Book actions based on the user's choice.
        /// </summary>
        /// <param name="option"></param>
        public List<Author> BookAuthorMenuProcessing(int option)
        {
            List<Author> bookAuthors = new List<Author>();
            AuthorService authorService = new AuthorService();

            switch (option)
            {
                case 1:
                    // show add new Author
                    // add it
                    // add it to book's Authors list
                    // add more? repeat until doesn't
                    // get FirstName
                    Console.Write(MenuOutput.AuthorFirstName);
                    string firstName = Console.ReadLine();

                    // get LastName
                    Console.Write(MenuOutput.AuthorLastName);
                    string lastName = Console.ReadLine();

                    // get Language
                    Console.Write(MenuOutput.AuthorLanguage);
                    string language = Console.ReadLine();

                    // get DateOfBirth
                    Console.Write(MenuOutput.AuthorDOB);
                    string dob = Console.ReadLine();
                    DateTime? dateOfBirth = DateHelper.ConvertStringToDate(dob);

                    while (dateOfBirth == null && dob != String.Empty)
                    {
                        Console.WriteLine(MenuErrors.WrongInputFormatError + MenuOutput.TryAgain);
                        dob = Console.ReadLine();
                        dateOfBirth = DateHelper.ConvertStringToDate(dob);
                    }

                    // get DateOfDeath
                    Console.Write(MenuOutput.AuthorDOD);
                    string dod = Console.ReadLine();
                    DateTime? dateOfDeath = DateHelper.ConvertStringToDate(dod);

                    while (dateOfDeath == null && dod != String.Empty)
                    {
                        Console.WriteLine(MenuErrors.WrongInputFormatError + MenuOutput.TryAgain);
                        dod = Console.ReadLine();
                        dateOfDeath = DateHelper.ConvertStringToDate(dod);
                    }

                    // insert new Author in DB --no more-- should be added directly when adding new Book                 
                    Author newAuthor = new Author(firstName, lastName, language, dateOfBirth, dateOfDeath);
                    bookAuthors.Add(newAuthor);
                    //authorService.AddNewAuthor(newAuthor);

                    ShowSuccessMessage(MenuSuccess.BookAuthorSavedInputs);

                    // go back to adding an Author's info
                    ShowMenu(EMenuType.EBookAuthorMenu);
                    while (!int.TryParse(Console.ReadLine(), out option))
                    {
                        Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                    }
                    
                    if(option == 1)
                        goto case 1;
                    ShowSuccessMessage(MenuSuccess.BookAuthorAddSuccess);
                    //ShowInfoMessage(MenuSuccess.CheckAuthorList);
                break;
            case 2:
                    // show all authors
                    // choose one
                    // add to book's Authors list, go back to book add new process
                    // add more? repeat until doesn't
                    
                    bool input = false;
                    do
                    {
                        Console.WriteLine("Getting data...");
                        IEnumerable<Author> authors = authorService.GetAllAuthors();
                        foreach (Author author in authors)
                        {
                            Console.WriteLine(author.Id + ". " + author.FirstName + " " + author.LastName);
                        }

                        int idAuthor = -1;

                        Console.WriteLine(MenuOutput.BookExistingAuthorChoice);
                        while (!int.TryParse(Console.ReadLine(), out idAuthor))
                        {
                            Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                        }
                        // TODO: verify if exists in database

                        Author foundAuthor = authorService.GetAuthorById(idAuthor);
                        if (foundAuthor == null)
                        {
                            ShowErrorMessage(MenuErrors.FailedAuthorGet);
                        }
                        else
                        {
                                bookAuthors.Add(foundAuthor);
                        }
                        Console.WriteLine(MenuOutput.AddMoreDomains);
                        string confirm = Console.ReadLine();

                        switch (confirm.ToUpper())
                        {
                            case "YES":
                            case "Y":
                                input = true;
                                break;
                            case "NO":
                            case "N":
                                input = false;
                                break;
                            default:
                                Console.WriteLine(MenuErrors.InvalidInputError);
                                input = false;
                                break;
                        }

                    } while (input == true);

                    break;
            case 3:
                    
                break;
            default:
                Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                break;
            }

            return bookAuthors;
        }

        /// <summary>
        /// Processes the Book actions based on the user's choice.
        /// </summary>
        /// <param name="option"></param>
        public void BookMenuProcessing(int option)
        {
            Clear();
            switch (option)
            {
                case 1:
                    Console.WriteLine(MenuOutput.BookEntries);
                    
                    // get Title
                    Console.Write(MenuOutput.BookTitle);
                    string title = Console.ReadLine();

                    // get list of Authors
                    Console.WriteLine(MenuOutput.BookAuthors);
                    ShowMenu(EMenuType.EBookAuthorMenu);
                    while (!int.TryParse(Console.ReadLine(), out option))
                    {
                        Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                    }

                    List<Author> authors = BookAuthorMenuProcessing(option);

                    foreach(var author in authors)
                    {
                        Console.WriteLine(author.ToString());
                    }

                    // get list of Domains
                    Console.WriteLine(MenuOutput.BookDomains);
                    List<Domain> domains = BookDomainMenuProcessing();

                    foreach (var domain in domains)
                    {
                        Console.WriteLine(domain.ToString());
                    }

                    // get list of Editions
                    Console.WriteLine(MenuOutput.BookEditions);
                    List<Edition> editions = BookEditionMenuProcessing();

                    foreach (var edition in editions)
                    {
                        Console.WriteLine(edition.ToString());
                    }

                    Book newBook = new Book(title, authors, domains, editions);
                    BookService bookService = new BookService();
                    bookService.AddNewBook(newBook);

                    ShowSuccessMessage(MenuSuccess.BookAddSuccess);
                    break;
                case 2:
                    // TODO: EditBorrower()
                    Console.WriteLine("EditBook()");
                    break;
                case 3:
                    // TODO: DeleteBorrower()
                    Console.WriteLine("DeleteBook()");
                    break;
                case 4:
                    // TODO: ShowAll()
                    Console.WriteLine("ShowAll()");
                    break;
                case 5:
                    // TODO: ShowAll()
                    Console.WriteLine("ShowAllForLibrary()");
                    break;
                case 6:
                    // TODO: ShowAll()
                    Console.WriteLine("ShowAllForLoan()");
                    break;
                case 7:
                    // TODO: SearchByTitle()
                    Console.WriteLine("SearchByTitle()");
                    break;
                case 8:
                    ShowMainMenu();
                    break;
                default:
                    Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                    break;
            }

            ShowBookMenu();
        }

        /// <summary>
        /// Gets the list of domains for a new book.
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        private List<Domain> BookDomainMenuProcessing()
        {
            List<Domain> bookDomains = new List<Domain>();
            DomainService domainService = new DomainService();

            bool input = false;
            do
            {
                Console.WriteLine("Getting data...");
                IEnumerable<Domain> domains = domainService.GetAllDomains();
                foreach (Domain domain in domains)
                {
                    Console.WriteLine(domain.Id + ". " + domain.DomainName);
                }

                int idDomain = -1;

                Console.WriteLine(MenuOutput.BookExistingDomainChoice);
                while (!int.TryParse(Console.ReadLine(), out idDomain))
                {
                    Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                }
                // TODO: verify if exists in database

                Domain foundDomain = domainService.GetDomainById(idDomain);
                if (foundDomain == null)
                {
                    ShowErrorMessage(MenuErrors.FailedDomainGet);
                }
                else
                {
                    bookDomains.Add(foundDomain);
                }
                Console.WriteLine(MenuOutput.AddMoreDomains);
                string confirm = Console.ReadLine();

                switch (confirm.ToUpper())
                {
                    case "YES":
                    case "Y":
                        input = true;
                        break;
                    case "NO":
                    case "N":
                        input = false;
                        break;
                    default:
                        Console.WriteLine(MenuErrors.InvalidInputError);
                        input = false;
                        break;
                }

            } while (input == true);

            return bookDomains;
        }

        /// <summary>
        /// Gets the list of editions for a new book.
        /// </summary>
        /// <param name="option"></param>
        private List<Edition> BookEditionMenuProcessing()
        {
            List<Edition> bookEditions = new List<Edition>();
            EditionService domainService = new EditionService();

            bool input = false;
            do
            {
                Console.Write(MenuOutput.EditionPublisher);
                string publisher = Console.ReadLine();

                // get Year
                Console.Write(MenuOutput.EditionYear);
                int year = -1; 
                while(!int.TryParse(Console.ReadLine(), out year))
                {
                    Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                }

                // get PageNumber
                Console.Write(MenuOutput.EditionPageNumber);
                int pageNumber = -1;
                while (!int.TryParse(Console.ReadLine(), out pageNumber))
                {
                    Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                }

                // get NoForLibrary
                Console.Write(MenuOutput.EditionNoForLibrary);
                int noForLibrary = -1;
                while (!int.TryParse(Console.ReadLine(), out noForLibrary))
                {
                    Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                }

                // get NoForLoan
                Console.Write(MenuOutput.EditionNoForLoan);
                int noForLoan = -1;
                while (!int.TryParse(Console.ReadLine(), out noForLoan))
                {
                    Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                }

                Edition newEdition = new Edition(publisher, pageNumber, year, EBookType.EHardCover, noForLibrary, noForLoan, new List<Loan>());
                bookEditions.Add(newEdition);

                Console.WriteLine(MenuOutput.AddMoreEditions);
                string confirm = Console.ReadLine();

                switch (confirm.ToUpper())
                {
                    case "YES":
                    case "Y":
                        input = true;
                        break;
                    case "NO":
                    case "N":
                        input = false;
                        break;
                    default:
                        Console.WriteLine(MenuErrors.InvalidInputError);
                        input = false;
                        break;
                }

            } while (input == true);

            return bookEditions;
        }

        #endregion

        #region [ Console Helpers ]

        /// <summary>
        /// Clears the console.
        /// </summary>
        private void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Displays an informative message in blue color.
        /// </summary>
        /// <param name="message"></param>
        private void ShowInfoMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Displays an error message in red color.
        /// </summary>
        /// <param name="message"></param>
        private void ShowErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Displays a success message in green color.
        /// </summary>
        /// <param name="message"></param>
        private void ShowSuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        #endregion
    }
}
