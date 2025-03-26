using System;
using System.Runtime.CompilerServices;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title) || title.Length > 100)
        {
            throw new ArgumentException("Judul video tidak valid. Panjang judul harus antara 1-100 karaktSer.");
        }

        Random random = new Random();
        this.id = random.Next(10000, 99999);

        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0 || count > 10000000)
        {
            throw new ArgumentException("Jumlah penambahan playCount tidak valid. Harus antara 0-10.000.000.");
        }

        try
        {
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException)
        {
            throw new OverflowException("PlayCount melebihi batas maksimum.");
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Video Details:");
        Console.WriteLine("ID: " + this.id);
        Console.WriteLine("Title: " + this.title);
        Console.WriteLine("Play Count: " + this.playCount);
    }
    public int GetPlayCount()
    {
        return this.playCount;
    }

    public string GetTitle()
    {
        return this.title;
    }
}


public class SayaTubeUser
{
    private int id;
    private string username;
    private List<SayaTubeVideo> uploadedVideos;

    public SayaTubeUser(string username)
    {
        if (string.IsNullOrEmpty(username) || username.Length > 100)
        {
            throw new ArgumentException("Username tidak valid. Panjang username harus antara 1-100 karakter.");
        }
        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.username = username;
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public int GetTotalVideoPlayCount()
    {
        int totalPlayCount = 0;
        foreach (SayaTubeVideo video in uploadedVideos)
        {
            totalPlayCount += video.GetPlayCount();
        }
        return totalPlayCount;
    }
    public void AddVideo(SayaTubeVideo video)
    {
        if (video == null)
        {
            throw new ArgumentNullException("Video tidak boleh null.");
        }
        if (video.GetPlayCount() > int.MaxValue)
        {
            throw new ArgumentException("Play count video melebihi batas maksimum.");
        }
        uploadedVideos.Add(video);
    }

    public void PrintAllVideoPlayCount()
    {
       Console.WriteLine($"User: {this.username}");
        for (int i = 0; i < uploadedVideos.Count; i++)
        {
            Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].GetTitle()}, Play Count: {uploadedVideos[i].GetPlayCount()}");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            SayaTubeUser user = new SayaTubeUser("Ariq Hisyam Nabil");
            SayaTubeVideo video1 = new SayaTubeVideo("Tutorial CSS bagi pemula");
            SayaTubeVideo video2 = new SayaTubeVideo("Tutorial Menggunakan JavaScript dijamin jago");
            SayaTubeVideo video3 = new SayaTubeVideo("3 jam jago HTML");

            video1.IncreasePlayCount(1000);
            video2.IncreasePlayCount(2000);
            video3.IncreasePlayCount(3000);

            SayaTubeUser user2 = new SayaTubeUser("103022300034");
            user.AddVideo(video1);
            user.AddVideo(video2);
            user.AddVideo(video3);

            Console.WriteLine("Total play count: " + user.GetTotalVideoPlayCount());

            user.PrintAllVideoPlayCount();
        
        }
        catch (Exception e)
        {
            Console.WriteLine("Eror" + e.Message);
        }
    }
}


