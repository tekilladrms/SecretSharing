using SecretSharing.Domain.Entities;
using SecretSharing.Domain.Exceptions;
using SecretSharing.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Domain.ValueObjects
{
    public sealed class S3Info : ValueObject
    {
        public string BucketName { get; private set; }

        public string FolderName { get; private set; }

        public string FileName { get; private set; }

        public string LocalPath { get; private set; }

        //For Ef
        private S3Info() { }

        private S3Info(string bucketName, string folderName, string fileName, string localPath)
        {
            BucketName = bucketName;
            FolderName = folderName;
            FileName = fileName;
            LocalPath = localPath;
        }

        public static S3Info Create(string bucketName, string folderName, string fileName, string localPath)
        {
            if(string.IsNullOrWhiteSpace(bucketName)) throw new ArgumentNullDomainException(nameof(bucketName));
            if(string.IsNullOrWhiteSpace(folderName)) throw new ArgumentNullDomainException(nameof(folderName));
            if(string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullDomainException(nameof(fileName));
            if(string.IsNullOrWhiteSpace(localPath)) throw new ArgumentNullDomainException(nameof(localPath));

            return new S3Info(bucketName, folderName, fileName, localPath);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return BucketName;
            yield return FolderName;
            yield return FileName;
            yield return LocalPath;
        }
    }
}
