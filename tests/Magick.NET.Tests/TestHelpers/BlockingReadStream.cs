// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Magick.NET.Tests;

internal sealed class BlockingReadStream : TestStream
{
    public BlockingReadStream(Stream innerStream)
      : base(innerStream, true)
    {
    }

    public override int Read(byte[] buffer, int offset, int count) => 0;

    public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
        await Task.Delay(Timeout.Infinite, cancellationToken).ConfigureAwait(false);
        return 0;
    }
}
