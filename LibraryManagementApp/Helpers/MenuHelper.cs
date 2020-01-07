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

        public void BorrowerMenuProcessing(int option)
        {
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

                    BorrowerService borrowerService = new BorrowerService();
                    AddressService addressService = new AddressService();
                    bool isInsertSuccessful = borrowerService.AddNewBorrower(firstName, lastName, email, dateOfBirth, readerFlg, librarianFlg) && addressService.AddNewAddress(city, street, number);

                    if(isInsertSuccessful)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("New borrower with address added successfuly!");
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
                    // TODO: ShowAll()
                    Console.WriteLine("ShowAll()");
                    break;
                case 5:
                    ShowMenu(EMenuType.EMainMenu);
                    break;
                default:
                    Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                    break;
            }
        }

        public void BookAuthorMenuProcessing(int option)
        {
            switch(option)
            {
                case 1:
                    // show Author dashboard
                    break;
                case 2:
                    // show all authors
                    // choose one
                    // add to list, go back to book add new process
                    break;
                default:
                    Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                    break;
            }
        }

        public void BookMenuProcessing(int option)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine(MenuOutput.BookEntries);
                    
                    Console.Write(MenuOutput.BookTitle);
                    string title = Console.ReadLine();

                    Console.Write(MenuOutput.BookAuthors);
                    ShowMenu(EMenuType.EBookAuthorMenu);
                    int choice;
                    while (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                    }

                    //if(1)
                    //ShowAvailableAuthors();
                    //if(2)
                    //AddNewAuthor();

                    //int pages;
                    //while (!int.TryParse(Console.ReadLine(), out pages))
                    //{
                    //    Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                    //}
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
