using AssetRipper.IO.Files.ResourceFiles;
using AssetRipper.IO.Files.SerializedFiles;
using System.Collections.Generic;

namespace AssetRipper.IO.Files
{
	public abstract class FileContainer : File
	{
		public IEnumerable<SerializedFile> FetchSerializedFiles()
		{
			foreach (SerializedFile file in SerializedFiles)
			{
				yield return file;
			}
			foreach (FileContainer list in FileLists)
			{
				foreach (SerializedFile file in list.FetchSerializedFiles())
				{
					yield return file;
				}
			}
		}

		public void AddFile(File file)
		{
			switch (file)
			{
				case SerializedFile serializedFile:
					AddSerializedFile(serializedFile);
					return;
				case ResourceFile resourceFile:
					AddResourceFile(resourceFile);
					return;
				case FileContainer fileList:
					AddFileContainer(fileList);
					return;
				default:
					throw new NotSupportedException(file.GetType().ToString());
			}
		}

		public void AddSerializedFile(SerializedFile file)
		{
			m_serializedFiles.Add(file);
			OnSerializedFileAdded(file);
		}

		public void AddFileContainer(FileContainer container)
		{
			m_fileLists.Add(container);
			OnFileContainerAdded(container);
		}

		public void AddResourceFile(ResourceFile resource)
		{
			m_resourceFiles.Add(resource);
			OnResourceFileAdded(resource);
		}

		protected virtual void OnSerializedFileAdded(SerializedFile file) { }

		protected virtual void OnFileContainerAdded(FileContainer container) { }

		protected virtual void OnResourceFileAdded(ResourceFile resource) { }

		public IReadOnlyList<SerializedFile> SerializedFiles => m_serializedFiles;
		public IReadOnlyList<FileContainer> FileLists => m_fileLists;
		public IReadOnlyList<ResourceFile> ResourceFiles => m_resourceFiles;

		private readonly List<SerializedFile> m_serializedFiles = new List<SerializedFile>(0);
		private readonly List<FileContainer> m_fileLists = new List<FileContainer>(0);
		private readonly List<ResourceFile> m_resourceFiles = new List<ResourceFile>(0);
	}
}
