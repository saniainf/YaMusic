create table [Tracks]
(
	[Id] int not null primary key,
	[Title] nvarchar(100) not null,
	[DurationMs] int not null,
	[CoverUri] nvarchar(200) not null,
	[LyricsAvailable] bit not null
);