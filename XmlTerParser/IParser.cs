namespace XmlTerParser
{
    public interface IParser
    {
        string Parse(string path_to_xml, IBuilder builder);
    }
}
