﻿using System.Threading.Tasks;
using ElectionResults.Core.Models;

namespace ElectionResults.Core.Services.BlobContainer
{
    public interface IBucketUploader
    {
        Task UploadFromUrl(ElectionResultsFile file);
    }
}