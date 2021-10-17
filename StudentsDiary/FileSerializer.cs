using System.IO;
using System.Xml.Serialization;

namespace StudentsDiary
{
	class FileSerializer<T> where T : new()
	{
		private readonly string _filePath;

		public FileSerializer(string filePath) => _filePath = filePath;

		public void SerializeToFile(T item)
		{
			string directoryName = Path.GetDirectoryName(_filePath);
			if (!Directory.Exists(directoryName))
				Directory.CreateDirectory(directoryName);

			using (StreamWriter streamWriter = new StreamWriter(_filePath))
			{
				var serializer = new XmlSerializer(typeof(T));
				serializer.Serialize(streamWriter, item);
			}
		}

		public T DeserializeFromFile()
		{
			if (!File.Exists(_filePath))
				return new T();

			using (StreamReader streamReader = new StreamReader(_filePath))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(T));
				var item = (T)serializer.Deserialize(streamReader);
				return item;
			}
		}
	}
}
