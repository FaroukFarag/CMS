﻿using System.Diagnostics.CodeAnalysis;

namespace CMS.Common.Tokens.Configurations;

public class JwtTokenSettings
{
    public static string SectionName = "JwtTokens";

    [NotNull]
    public string ValidIssuer { get; set; } = default!;

    [NotNull]
    public string ValidAudience { get; set; } = default!;

    [NotNull]
    public string SecretKey { get; set; } = default!;

    [NotNull]
    public int LifeTime { get; set; } = default!;
}
