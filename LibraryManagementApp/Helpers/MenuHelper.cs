﻿using System;
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
        private int option;

        private Dictionary<int, string> menu;

        public MenuHelper()
        {
            
        }

        private void ShowMenu(EMenuType menuType)
        {
            menu = new Dictionary<int, string>();


            switch (menuType)
            {
                case EMenuType.EMainMenu:
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
                    menu.Add(5, MenuOutput.Back);
                    break;
                case EMenuType.EBorrowerMenu:
                    menu.Add(1, MenuOutput.AddNew);
                    menu.Add(2, MenuOutput.BorrowerEdit);
                    menu.Add(3, MenuOutput.BorrowerDelete);
                    menu.Add(4, MenuOutput.BorrowerShowAll);
                    menu.Add(5, MenuOutput.Back);
                    break;
                default:
                    Console.WriteLine("ERROR");
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

                    // TODO: Finish Add New Borrower

                    //Console.WriteLine(firstName+lastName+email+dob+city+street+number);
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
                    Console.Clear();
                    ShowMainMenu();
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

                    Console.WriteLine("Author(s):");
                    Console.WriteLine("1. AddExistingAuthor");
                    Console.WriteLine("2. AddNewAuthor");

                    //int choice;
                    //while (!int.TryParse(Console.ReadLine(), out choice))
                    //{
                    //    Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                    //}

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
                    Console.WriteLine("ShowMainMenu()");
                    break;
                default:
                    Console.WriteLine(MenuErrors.InvalidInputError + MenuOutput.TryAgain);
                    break;
            }
        }
    }
}