using System;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Repositories;
using ApplicationCore.Contracts.Repositories;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Infrastructure.Service
{
	public class BlobService //: IBlobService
	{
        //private readonly BlobServiceClient _blobServiceClient;
        //private BlobContainerClient _clientContainer;
        //public BlobService(BlobServiceClient blobServiceClient)
        //{
        //    _blobServiceClient = blobServiceClient;
        //    _clientContainer = _blobServiceClient.GetBlobContainerClient("resumes");
        //}

        //public Task DeleteBlobAsync(string blobName)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<BlobResponseModel> GetBlobAsyc(string name)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<string>> ListBlobsAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UploadFileBlobAsync(string filePath, string fileName)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

