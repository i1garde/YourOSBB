using System.ComponentModel;

namespace YourOSBB.Entities;

public static class Roles
{
    public static Func<string> OsbbHead = () => "Голова ОСББ";
    public static Func<string> Resident = () => "Мешканець";
}