﻿using AssetRipper.Assets.Bundles;

namespace AssetRipper.Assets.Collections;

/// <summary>
/// A collection of artificial assets generated during asset processing.
/// </summary>
public class ProcessedAssetCollection : VirtualAssetCollection
{
	public ProcessedAssetCollection(Bundle bundle) : base(bundle)
	{
	}

	protected override bool IsValidDependency(AssetCollection dependency)
	{
		return dependency is SerializedAssetCollection or ProcessedAssetCollection;
	}
}

