using Controller;
using Models;

RPController rc = new RPController();
List<Infracao> list;
list = rc.GetAll();
Console.WriteLine(rc.InsertInMongo(list));
