using DomainModel;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp
{
    /// <summary>
    /// A helper class for the menu shown in the console user interface.
    /// </summary>
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
                    Console.Clear();
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
                    //ShowAuthorMenu();
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
                    
                    bool isInsertSuccessful = borrowerService.AddNewBorrower(firstName, lastName, email, dateOfBirth, readerFlg, librarianFlg, city, street, number);

                    if(isInsertSuccessful)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(MenuSuccess.BorrowerAddSuccess);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(MenuErrors.FailedBorrowerInsert);
                        Console.ForegroundColor = ConsoleColor.White;
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
                    Console.Write(MenuOutput.AuthorFirstName);
                    string firstName = Console.ReadLine();

                    Console.Write(MenuOutput.AuthorLastName);
                    string lastName = Console.ReadLine();

                    Console.Write(MenuOutput.AuthorLanguage);
                    string language = Console.ReadLine();

                    Console.Write(MenuOutput.AuthorDOB);
                    string dob = Console.ReadLine();
                    DateTime? dateOfBirth = DateHelper.ConvertStringToDate(dob);

                    while (dateOfBirth == null && dob != String.Empty)
                    {
                        Console.WriteLine(MenuErrors.WrongInputFormatError + MenuOutput.TryAgain);
                        dob = Console.ReadLine();
                        dateOfBirth = DateHelper.ConvertStringToDate(dob);
                    }

                    Console.Write(MenuOutput.AuthorDOD);
                    string dod = Console.ReadLine();
                    DateTime? dateOfDeath = DateHelper.ConvertStringToDate(dod);

                    while (dateOfDeath == null && dod != String.Empty)
                    {
                        Console.WriteLine(MenuErrors.WrongInputFormatError + MenuOutput.TryAgain);
                        dod = Console.ReadLine();
                        dateOfDeath = DateHelper.ConvertStringToDate(dod);
                    }

                    // insert new Author in DB                    
                    Author newAuthor = new Author(firstName, lastName, language, dateOfBirth, dateOfDeath);
                    bookAuthors.Add(newAuthor);
                    //authorService.AddNewAuthor(firstName, lastName, language, dateOfBirth, dateOfDeath);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(MenuSuccess.BookAuthorSavedInputs);
                    Console.ForegroundColor = ConsoleColor.White;

                    ShowMenu(EMenuType.EBookAuthorMenu);
                    while (!int.TryParse(Console.ReadLine(), out option))
                    {
                        Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                    }

                    if(option == 1)
                        goto case 1;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(MenuSuccess.BookAuthorAddSuccess);
                    //Console.ForegroundColor = ConsoleColor.Blue;
                    //Console.WriteLine(MenuSuccess.CheckAuthorList);
                    Console.ForegroundColor = ConsoleColor.White;
                break;
            case 2:
                    // show all authors
                    // choose one
                    // add to book's Authors list, go back to book add new process
                    // add more? repeat until doesn't
                    Console.WriteLine("Getting the data...");
                    //IEnumerable<Author> authors = authorService.GetAllAuthors();
                    //foreach(Author author in authors)
                    //{
                    //    Console.WriteLine(author.Id + " " + author.FirstName + " " + author.LastName);
                    //}

                    Console.WriteLine(MenuOutput.BookExistingAuthorChoice);
                    int idAuthor = 0;
                    while (!int.TryParse(Console.ReadLine(), out idAuthor))
                    {
                        Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                    }

                    //Author selectedAuthor = authorService.getAuthor(idAuthor);
                    //bookAuthors.Add(selectedAuthor);

                    break;
            case 3:
                Console.WriteLine("Gone back to adding Book");
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
            switch (option)
            {
                case 1:
                    Console.WriteLine(MenuOutput.BookEntries);
                    
                    Console.Write(MenuOutput.BookTitle);
                    string title = Console.ReadLine();

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

                    Console.WriteLine("Came back to adding new Book");
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
                    ShowMenu(EMenuType.EMainMenu);
                    break;
                default:
                    Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                    break;
            }
        }

        #endregion
    }
}
