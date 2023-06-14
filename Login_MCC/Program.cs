using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, User> users = new Dictionary<string, User>();

    static void Main()
    {
        while (true)
        {
            // Menampilkan opsi menu
            Console.WriteLine("=== OTENTIKASI DASAR ===");
            Console.WriteLine("1. Buat Pengguna");
            Console.WriteLine("2. Tampilkan Pengguna");
            Console.WriteLine("3. Cari Pengguna");
            Console.WriteLine("4. Masuk dengan Pengguna");
            Console.WriteLine("5. Keluar");

            // Meminta input dari pengguna
            Console.Write("Masukkan pilihan Anda: ");
            string choice = Console.ReadLine();

            // Memproses pilihan pengguna
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
                    LoginUser();
                    break;
                case "5":
                    ExitProgram();
                    return;
                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void ExitProgram()
    {
        // Kode untuk keluar dari program
        Console.WriteLine("Keluar dari program...");
        // ...
    }

    static void CreateUser()
    {
        // Kode untuk membuat pengguna baru
        Console.WriteLine("Membuat pengguna baru...");

        Console.Write("Masukkan nama depan: ");
        string firstName = Console.ReadLine();

        Console.Write("Masukkan nama belakang: ");
        string lastName = Console.ReadLine();

        Console.Write("Masukkan kata sandi: ");
        string password = Console.ReadLine();

        // Menghasilkan ID pengguna unik
        string userId = Guid.NewGuid().ToString();

        // Menghasilkan nama pengguna dengan menggabungkan nama depan dan belakang (diubah menjadi huruf kecil)
        string username = $"{firstName.ToLower()}{lastName.ToLower()}";

        // Membuat objek User baru
        User newUser = new User(userId, firstName, lastName, username, password);

        // Menambahkan pengguna ke kamus dengan nama pengguna sebagai kunci
        users.Add(username, newUser);

        Console.WriteLine("Pengguna berhasil dibuat.");
    }

    static void ShowUser()
    {
        // Kode untuk menampilkan semua pengguna yang ada
        Console.WriteLine("Menampilkan semua pengguna...");

        if (users.Count == 0)
        {
            Console.WriteLine("Tidak ada pengguna yang ditemukan.");
            return;
        }

        Console.WriteLine("Daftar Pengguna:");
        foreach (var user in users)
        {
            string username = user.Key;
            User userInfo = user.Value;

            Console.WriteLine($"Nama Pengguna: {username}");
        }

        Console.WriteLine();

        // Menampilkan opsi tambahan
        Console.WriteLine("Opsi Tambahan:");
        Console.WriteLine("1. Edit Password Pengguna");
        Console.WriteLine("2. Edit Nama Pengguna");
        Console.WriteLine("3. Hapus Pengguna");
        Console.WriteLine("4. Kembali");

        // Meminta input dari pengguna
        Console.Write("Masukkan pilihan Anda: ");
        string choice = Console.ReadLine();

        // Memproses pilihan tambahan dari pengguna
        switch (choice)
        {
            case "1":
                EditPasswordUser();
                break;
            case "2":
                EditUsername();
                break;
            case "3":
                DeleteUser();
                break;
            case "4":
                return;
            default:
                Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                break;
        }
    }

    static void SearchUser()
    {
        // Kode untuk mencari pengguna tertentu
        Console.WriteLine("Mencari pengguna...");

        // ...
    }

    static void LoginUser()
    {
        // Kode untuk mengotentikasi dan masuk dengan pengguna
        Console.WriteLine("Masuk dengan pengguna...");

        Console.WriteLine("Masukkan Nama Pengguna");

        Console.WriteLine("Masukkan Password");


        if (User.ContainsKey(username))
        {
            User userToLogin = users[username];

            if (userToLogin.Password == password)
            {
                Console.WriteLine("Login Berhasil");

                bool isAdmin = EditUsername().ToLower() == "Admin";


                if (isAdmin)
                {
                    AdminMenu();
                }
                else
                {
                    Usermenu(userToLogin);
                }


                return:
            }
        }

        Console.WriteLine("Nama Pengguna atau Password salah");
    }

    static void EditPasswordUser()
    {
        // Kode untuk mengedit password pengguna
        Console.WriteLine("Mengedit password pengguna...");

        Console.Write("Masukkan nama pengguna: ");
        string username = Console.ReadLine();

        if (users.ContainsKey(username))
        {
            User userToEdit = users[username];

            Console.Write("Masukkan kata sandi saat ini: ");
            string currentPassword = Console.ReadLine();

            if (userToEdit.Password == currentPassword)
            {
                Console.Write("Masukkan password baru: ");
                string newPassword = Console.ReadLine();

                userToEdit.Password = newPassword;
                Console.WriteLine("Password pengguna berhasil diperbarui.");
            }
            else
            {
                Console.WriteLine("Kata sandi saat ini salah. Password pengguna tidak diperbarui.");
            }
        }
        else
        {
            Console.WriteLine("Pengguna tidak ditemukan.");
        }
    }

    static void EditUsername()
    {
        // Kode untuk mengedit nama pengguna
        Console.WriteLine("Mengedit nama pengguna...");

        Console.Write("Masukkan nama pengguna yang ingin diubah: ");
        string currentUsername = Console.ReadLine();

        if (users.ContainsKey(currentUsername))
        {
            Console.Write("Masukkan kata sandi pengguna: ");
            string password = Console.ReadLine();

            User userToEdit = users[currentUsername];

            if (userToEdit.Password == password)
            {
                Console.Write("Masukkan nama pengguna baru: ");
                string newUsername = Console.ReadLine();

                // Menghapus pengguna dari kamus dengan nama pengguna lama
                users.Remove(currentUsername);

                // Menambahkan pengguna ke kamus dengan nama pengguna baru
                users.Add(newUsername, userToEdit);

                // Mengupdate nama pengguna pada objek User
                userToEdit.Username = newUsername;

                Console.WriteLine("Nama pengguna berhasil diperbarui.");
            }
            else
            {
                Console.WriteLine("Kata sandi salah. Nama pengguna tidak diperbarui.");
            }
        }
        else
        {
            Console.WriteLine("Pengguna tidak ditemukan.");
        }
    }

    static void DeleteUser()
    {
        // Kode untuk menghapus pengguna
        Console.WriteLine("Menghapus pengguna...");

        Console.Write("Masukkan nama pengguna yang ingin dihapus: ");
        string usernameToDelete = Console.ReadLine();

        if (users.ContainsKey(usernameToDelete))
        {
            users.Remove(usernameToDelete);
            Console.WriteLine("Pengguna berhasil dihapus.");
        }
        else
        {
            Console.WriteLine("Pengguna tidak ditemukan.");
        }
    }
}

class User
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public User(string id, string firstName, string lastName, string username, string password)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        FullName = $"{firstName} {lastName}";
        Username = username;
        Password = password;
    }
}
