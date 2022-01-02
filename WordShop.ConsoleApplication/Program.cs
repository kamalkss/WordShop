// See https://aka.ms/new-console-template for more information
using WordShop.ConsoleApplication;

Console.WriteLine("Welcome to The PostCode information application\nThis Application Use a webapi to download and process the data" +
                  "\nPlease first Choose number 1 to Download the Data");

A:

Console.WriteLine("Please choose your option:\n1. Download The Data\n2. Get PostCode Details\n3. Get PostCode Details With Range" +
                  "\n4. Get PostCode Details with Coordinate\n5. Get PostCode Details With Coordinate and Range\n0. Exit");
int reply = Convert.ToInt32(Console.ReadLine());

try
{
    switch (reply)
    {
        case 1:
            Console.WriteLine("********************************************************\n\n\n");
            Console.WriteLine("Please Wait");
            CallApi.DownloadData().GetAwaiter().GetResult();
            Console.WriteLine("********************************************************\n\n\n");
            break;
        case 2:
            Console.WriteLine("********************************************************\n\n\n");
            Console.WriteLine("Please Enter your PostCode : ");
            string? PostCode = Console.ReadLine();
            if (PostCode != null) CallApi.GetPostCodeDetails(PostCode).GetAwaiter().GetResult();
            Console.WriteLine("********************************************************\n\n\n");
            break;
        case 3:
            Console.WriteLine("********************************************************\n\n\n");
            Console.WriteLine("Please Enter Your PostCode on First Line And Your Range in Second Line");
            Console.Write("PostCode:\t");
            string? PostCodeRange = Console.ReadLine();
            Console.Write("Range:\t");
            int Range = Convert.ToInt32(Console.ReadLine());
            if (PostCodeRange != null && Range != null) CallApi.GetPostCodesWithRanges(PostCodeRange, Range)
                .GetAwaiter().GetResult();
            Console.WriteLine("********************************************************\n\n\n");
            break;
        case 4:
            Console.WriteLine("********************************************************\n\n\n");
            Console.WriteLine("Please Enter Your latitude on First Line And Your longitude in Second Line");
            Console.Write("latitude:\t");
            double latitude = Convert.ToDouble(Console.ReadLine());
            Console.Write("longitude:\t");
            double longitude = Convert.ToDouble(Console.ReadLine());
            if (latitude != null && longitude != null) CallApi.GetPostCodesWithCoordinate(latitude, longitude)
                .GetAwaiter().GetResult();
            Console.WriteLine("********************************************************\n\n\n");
            break;
        case 5:
            Console.WriteLine("********************************************************\n\n\n");
            Console.WriteLine("Please Enter Your latitude on First Line And Your longitude in Second Line and your Range in the Third Line");
            Console.Write("latitude:\t");
            double latitudeRange = Convert.ToDouble(Console.ReadLine());
            Console.Write("longitude:\t");
            double longitudeRange = Convert.ToDouble(Console.ReadLine());
            Console.Write("Range:\t");
            int CoordinateRange = Convert.ToInt32(Console.ReadLine());
            if (latitudeRange != null && longitudeRange != null && CoordinateRange != null)
            {
                CallApi.GetPostCodesWithCoordinateAndRange(latitudeRange, longitudeRange,CoordinateRange)
                    .GetAwaiter().GetResult();
            }
            Console.WriteLine("********************************************************\n\n\n");
            break;
        case 0:
            
            break;
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

goto A;
