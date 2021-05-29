using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution
{

    public class NotesStore
    {
        public string Name;
        public string State;
        List<NotesStore> Notestore = new List<NotesStore>();

        public NotesStore()
        {
        }
        public void AddNote(String state, String name)
        {
            if (string.IsNullOrEmpty(name)) { throw new ArgumentException("Name cannot be empty"); }
            if (!string.IsNullOrEmpty(name) && state != "completed" && state != "active" && state != "others")
            {
                throw new ArgumentException("Invalid state " + state);
            }
            else
            {
                Notestore.Add(new NotesStore()
                {
                    Name = name,
                    State = state
                });
            }
        }
        public List<String> GetNotes(String state)
        {
            if (state != "completed" && state != "active" && state != "others")
            { throw new ArgumentException("Invalid state " + state); }

            return Notestore.Where(x => x.State == state).Select(x => x.Name).ToList();
        }
    }

    public class Solution
    {
        public static void Main()
        {
            var notesStoreObj = new NotesStore();
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++)
            {
                var operationInfo = Console.ReadLine().Split(' ');
                try
                {
                    if (operationInfo[0] == "AddNote")
                        notesStoreObj.AddNote(operationInfo[1], operationInfo.Length == 2 ? "" : operationInfo[2]);
                    else if (operationInfo[0] == "GetNotes")
                    {
                        var result = notesStoreObj.GetNotes(operationInfo[1]);
                        if (result.Count == 0)
                            Console.WriteLine("No Notes");
                        else
                            Console.WriteLine(string.Join(",", result));
                    }
                    else
                    {
                        Console.WriteLine("Invalid Parameter");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }

            Console.ReadLine();
        }
    }
}