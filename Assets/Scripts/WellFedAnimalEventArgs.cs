using System;

public class WellFedAnimalEventArgs : EventArgs
{
    public WellFedAnimalEventArgs(string animalName, float animalPoint)
    {
        this.AnimalName = animalName;
        this.AnimalPoint = animalPoint;
    }

    public string AnimalName { get; set; }

    public float AnimalPoint { get; set; }
}