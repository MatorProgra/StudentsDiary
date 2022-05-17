using System.Xml.Serialization;

namespace StudentsDiary_Net6
{
	internal class FileSerializer<T> where T : new()
	{
		private readonly string _filePath;

		public FileSerializer(string filePath) => _filePath = filePath;

		public void SerializeToFile(T item)
		{
			var directoryName = Path.GetDirectoryName(_filePath);
			if (!string.IsNullOrWhiteSpace(directoryName) && !Directory.Exists(directoryName))
				Directory.CreateDirectory(directoryName);

			using (var streamWriter = new StreamWriter(_filePath))
			{
				var serializer = new XmlSerializer(typeof(T));
				serializer.Serialize(streamWriter, item);
			}
		}

		public T DeserializeFromFile()
		{
			if (!File.Exists(_filePath))
				return new T();

			using (var streamReader = new StreamReader(_filePath))
			{
				var serializer = new XmlSerializer(typeof(T));
				var item = (T)serializer.Deserialize(streamReader)!;
				return item;
			}
		}
	}
}
