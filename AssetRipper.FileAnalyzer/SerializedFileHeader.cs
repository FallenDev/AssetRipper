﻿namespace AssetRipper.FileAnalyzer
{
	public class SerializedFileHeader
	{
		public uint m_MetadataSize;
		public long m_FileSize;
		public SerializedFileFormatVersion m_Version;
		public long m_DataOffset;
		public byte m_Endianess;
		public byte[] m_Reserved;
	}
}
