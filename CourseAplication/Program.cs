using CourseAplication.Controllers;
using Service.Helpers.Enums;
using Service.Helpers.Extention;

GroupController groupController = new();
while (true)
{
    GetMenues();
    Operation: string operationStr = Console.ReadLine();
    int operation;
    bool isCorrectOperationFormat = int.TryParse(operationStr, out operation);
    if (isCorrectOperationFormat)
    {
        switch (operation)
        {
            case (int)OperatingType.GroupCreat:
                groupController.Create();
                break;

            case (int)OperatingType.GroupDelete:
                groupController.Delete();
                break;

            case (int)OperatingType.GetAllGroup:
                groupController.GetAllGroups();
                break;

            default:
                ConsoleColor.Red.WriteConsole("fgdhg");
                goto Operation;


        }


    }
    else
    {
        ConsoleColor.Red.WriteConsole("Operation format is wrong, please add operation again");
        goto Operation;
    }
}





static void GetMenues()
{
    ConsoleColor.Cyan.WriteConsole("Choose one operation :  1-Group create, 2-Group delete, 3-Get all Groups, 4-Edit Group");
}
