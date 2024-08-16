namespace StudentApiWithEF.Models
{
    public class SubTask
    {
        public int Id { get; set; }
        public string SubTaskName { get; set; }
        public string SubTaskDescription { get; set; }


        // FK
        public int TaskId { get; set; }

        public Task? Task { get; set; }
    }
}
