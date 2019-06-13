namespace P04_Hospital
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Department
    {
        private int capacity;

        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
            this.capacity = 20;
        }

        public string Name { get; set; }

        public List<Room> Rooms { get; private set; }

        public bool AddRoom()
        {
            if (this.Rooms.Count < capacity)
            {
                this.Rooms.Add(new Room());
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddPatient(string name)
        {
            if (!this.Rooms.Any())
            {
                AddRoom();
            }

            int currentRoomIndex = this.Rooms.Count - 1;
            var currentRoom = this.Rooms[currentRoomIndex];
            bool patientIsAdded = currentRoom.AddPatient(name);

            if (!patientIsAdded)
            {
                bool newRoomIsAdded = this.AddRoom();

                if (newRoomIsAdded)
                {
                    this.Rooms[currentRoomIndex + 1].AddPatient(name);
                }
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var room in this.Rooms)
            {
                sb.AppendLine(room.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
