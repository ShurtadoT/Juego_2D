[System.Serializable]
public class ItemData
{
    public int id;
    public string type;
    public string description;
    public int cantidad;
    public string iconPath;

    public ItemData(int id, string type, string description, int cantidad, string iconPath)
    {
        this.id = id;
        this.type = type;
        this.description = description;
        this.cantidad = cantidad;
        this.iconPath = iconPath;
    }
}