using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static List<string> users = new List<string>();

    static void Main(string[] args)
    {
        GetAllRegions();
        Login();
        Console.ReadLine();
    }

   

    public static int InsertRegion(string nama)
    {
        int result = 0;
        
        using ("" )
        {
            Connection.connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO regions (region_name) VALUES (@region_name)";
                command.Transaction = transaction;

                SqlParameter pName = new SqlParameter("@region_name", nama);
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                command.Parameters.Add(pName);

                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    Console.WriteLine(ex2.Message);
                }
            }
        }
        return result;
    }

    static void GetAllRegions()
    {
        string connectionString = "Data Source=GILANG_AKRAM;Database=db_hr;Integrated Security=True;Connect Timeout=30;";
        
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connected!");

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM tb_m_regions";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);

                            Console.WriteLine("ID: " + id + ", Name: " + name);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection failed: " + ex.Message);
            }
        }
    }
    public static int UpdateRegion(int id, string name)
    {
        int result = 0;
        

        SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            // create instance for command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE tb_m_regions SET name = @name WHERE id = @id";
            command.Transaction = transaction;


            // create parameter Id
            SqlParameter parameterName = new SqlParameter();
            parameterName.ParameterName = "@id";
            parameterName.Value = id;
            parameterName.SqlDbType = SqlDbType.Int;

            // create parameter Name
            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@name";
            parameterId.Value = name;
            parameterId.SqlDbType = SqlDbType.VarChar;

            // add parameter
            command.Parameters.Add(parameterName);
            command.Parameters.Add(parameterId);

            // run command
            result = command.ExecuteNonQuery();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception rollback)
            {
                Console.WriteLine(rollback.Message);
            }

        }
       connection.Close();
        return result;
    }
   
    static void Login()
    {
        Console.WriteLine("=== HALAMAN LOGIN ===");

        while (true)
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (username == "admin" && password == "admin123")
            {
                Console.WriteLine("Berhasil login sebagai Admin.");
                AdminMenu();
                break;
            }
            else if (username == "user" && password == "user123")
            {
                Console.WriteLine("Berhasil login sebagai Pengguna.");
                UserMenu();
                break;
            }
            else
            {
                Console.WriteLine("Username atau password salah. Silakan coba lagi.");
            }
        }
    }

    static void AdminMenu()
    {
        while (true)
        {
            Console.WriteLine("=== MENU ADMIN ===");
            Console.WriteLine("1. Buat Pengguna");
            Console.WriteLine("2. Tampilkan Pengguna");
            Console.WriteLine("3. Cari Pengguna");
            Console.WriteLine("4. Logout");
            Console.WriteLine("5. Keluar");

            Console.Write("Masukkan pilihan Anda: ");
            string choice = Console.ReadLine();

            Console.Clear(); // Membersihkan layar setelah memilih opsi

            switch (choice)
            {
                case "1":
                    CreateUser();
                    break;
                case "2":
                    ShowUser();
                    break;
                case "3":
                    SearchUser();
                    break;
                case "4":
                    Console.WriteLine("Berhasil logout dari akun Admin.");
                    Login();
                    return;
                case "5":
                    Console.WriteLine("Terima kasih!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void UserMenu()
    {
        int choice = 0;

        while (choice != 4)
        {
            DisplayUserMenu();
            Console.Write("Pilihan: ");
            choice = int.Parse(Console.ReadLine());

            Console.Clear(); // Membersihkan layar setelah memilih opsi

            switch (choice)
            {
                case 1:
                    CheckOddEven();
                    break;
                case 2:
                    PrintOddEvenWithLimit();
                    break;
                case 3:
                    Console.WriteLine("Berhasil logout dari User.");
                    Login();
                    break;
                case 4:
                    Console.WriteLine("Terima kasih!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid!");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void DisplayUserMenu()
    {
        Console.WriteLine("======================================");
        Console.WriteLine("MENU PENGGUNA");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("1. Cek Ganjil Genap");
        Console.WriteLine("2. Print Ganjil/Genap (dengan Limit)");
        Console.WriteLine("3. Logout");
        Console.WriteLine("4. Keluar");
        Console.WriteLine("--------------------------------------");
    }

    static void CreateUser()
    {
        Console.Write("Masukkan nama pengguna: ");
        string username = Console.ReadLine();
        users.Add(username);
        Console.WriteLine("Pengguna dengan nama '" + username + "' berhasil ditambahkan.");
    }

    static void ShowUser()
    {
        if (users.Count > 0)
        {
            Console.WriteLine("=== DAFTAR PENGGUNA ===");
            foreach (string user in users)
            {
                Console.WriteLine(user);
            }
        }
        else
        {
            Console.WriteLine("Belum ada pengguna terdaftar.");
        }
    }

    static void SearchUser()
    {
        Console.Write("Masukkan nama pengguna yang ingin dicari: ");
        string keyword = Console.ReadLine();
        bool found = false;

        foreach (string user in users)
        {
            if (user.Contains(keyword))
            {
                Console.WriteLine("Pengguna dengan nama '" + user + "' ditemukan.");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Pengguna dengan nama '" + keyword + "' tidak ditemukan.");
        }
    }

    static void CheckOddEven()
    {
        Console.Write("Masukkan bilangan yang ingin dicek: ");
        int number;

        if (int.TryParse(Console.ReadLine(), out number))
        {
            if (number >= 0)
            {
                if (number % 2 == 0)
                {
                    Console.WriteLine(number + " adalah bilangan genap.");
                }
                else
                {
                    Console.WriteLine(number + " adalah bilangan ganjil.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Input!!!");
            }
        }
        else
        {
            Console.WriteLine("Invalid Input!!!");
        }
    }

    static void PrintOddEvenWithLimit()
    {
        Console.Write("Pilih (Ganjil/Genap): ");
        string choice = Console.ReadLine();

        if (choice.ToLower() == "ganjil" || choice.ToLower() == "genap")
        {
            Console.Write("Masukkan batas: ");
            int limit;

            if (int.TryParse(Console.ReadLine(), out limit))
            {
                if (limit >= 1)
                {
                    Console.Write("Print bilangan 1 - " + limit + ": ");
                    for (int i = 1; i <= limit; i++)
                    {
                        if ((i % 2 == 0 && choice.ToLower() == "genap") || (i % 2 != 0 && choice.ToLower() == "ganjil"))
                        {
                            Console.Write(i);
                            if (i != limit)
                            {
                                Console.Write(", ");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Input limit tidak valid!!!");
                }
            }
            else
            {
                Console.WriteLine("Invalid Input!!!");
            }
        }
        else
        {
            Console.WriteLine("Input pilihan tidak valid!!!");
        }
    }
}
