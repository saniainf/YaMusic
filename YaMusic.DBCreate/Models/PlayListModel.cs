using System.Text.Json.Serialization;

namespace YaMusic.DBCreate.Models
{
    public class Album
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("metaType")]
        public string MetaType { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("releaseDate")]
        public DateTime ReleaseDate { get; set; }

        [JsonPropertyName("coverUri")]
        public string CoverUri { get; set; }

        [JsonPropertyName("ogImage")]
        public string OgImage { get; set; }

        [JsonPropertyName("genre")]
        public string Genre { get; set; }

        [JsonPropertyName("trackCount")]
        public int TrackCount { get; set; }

        [JsonPropertyName("likesCount")]
        public int LikesCount { get; set; }

        [JsonPropertyName("recent")]
        public bool Recent { get; set; }

        [JsonPropertyName("veryImportant")]
        public bool VeryImportant { get; set; }

        [JsonPropertyName("artists")]
        public List<Artist> Artists { get; set; }

        [JsonPropertyName("labels")]
        public List<Label> Labels { get; set; }

        [JsonPropertyName("available")]
        public bool Available { get; set; }

        [JsonPropertyName("availableForPremiumUsers")]
        public bool AvailableForPremiumUsers { get; set; }

        [JsonPropertyName("availableForOptions")]
        public List<string> AvailableForOptions { get; set; }

        [JsonPropertyName("availableForMobile")]
        public bool AvailableForMobile { get; set; }

        [JsonPropertyName("availablePartially")]
        public bool AvailablePartially { get; set; }

        [JsonPropertyName("bests")]
        public List<int> Bests { get; set; }

        [JsonPropertyName("trackPosition")]
        public TrackPosition TrackPosition { get; set; }

        public static readonly Dictionary<string, string> Genres = new()
        {
            { "all", "Музыка всех жанров" },
            { "pop", "Поп" },
            { "allrock", "Рок" },
            { "indie", "Инди" },
            { "metal", "Метал" },
            { "alternative", "Альтернатива" },
            { "electronics", "Электроника" },
            { "electronic", "Электроника" },
            { "dance", "Танцевальная" },
            { "rap", "Рэп и хип-хоп" },
            { "hip-hop", "Рэп и хип-хоп" },
            { "rnb", "RnB" },
            { "r-n-b", "RnB" },
            { "jazz", "Джаз" },
            { "blues", "Блюз" },
            { "reggae", "Регги" },
            { "ska", "Ска" },
            { "punk", "Панк" },
            { "folk", "Музыка мира" },
            { "world", "Музыка мира" },
            { "estrada", "Эстрада" },
            { "shanson", "Шансон" },
            { "country", "Кантри" },
            { "soundtrack", "Саундтреки" },
            { "relax", "Лёгкая музыка" },
            { "easy", "Лёгкая музыка" },
            { "children", "Детская музыка со всего мира" },
            { "naturesounds", "Звуки природы и шум города" },
            { "bard", "Авторская песня" },
            { "singer-songwriter", "Авторская песня" },
            { "forchildren", "Детская" },
            { "for-children", "Детская" },
            { "fairytales", "Аудиосказки" },
            { "poemsforchildren", "Стихи для детей" },
            { "podcasts", "Подкасты" },
            { "podcast", "Подкасты" },
            { "classicalmusic", "Классика" },
            { "fiction", "Художественная литература" },
            { "nonfictionliterature", "Нон-фикшн" },
            { "booksnotinrussian", "Аудиокниги на иностранном языке" },
            { "audiobooks", "Разговорное" },
            { "readings", "Разговорное" },
            { "other", "Другое" },
            { "ruspop", "Русская поп-музыка" },
            { "disco", "Диско" },
            { "kpop", "K-pop" },
            { "turkishpop", "Турецкая поп-музыка" },
            { "uzbekpop", "Узбекская поп-музыка" },
            { "japanesepop", "J-pop" },
            { "israelipop", "Израильская поп-музыка" },
            { "azerbaijanpop", "Азербайджанская поп-музыка" },
            { "hyperpopgenre", "Гиперпоп" },
            { "rusrock", "Русский рок" },
            { "rnr", "Рок-н-ролл" },
            { "rock-n-roll", "Рок-н-ролл" },
            { "prog", "Прогрессивный рок" },
            { "prog-rock", "Прогрессивный рок" },
            { "postrock", "Построк" },
            { "post-rock", "Построк" },
            { "newwave", "New Wave" },
            { "new-wave", "New Wave" },
            { "ukrrock", "Украинский рок" },
            { "folkrock", "Фолк-рок" },
            { "stonerrock", "Стоунер-рок" },
            { "hardrock", "Хард-рок" },
            { "turkishrock", "Турецкий рок" },
            { "rock", "Иностранный рок" },
            { "israelirock", "Израильский рок" },
            { "local-indie", "Местное инди" },
            { "progmetal", "Прогрессив" },
            { "epicmetal", "Эпический" },
            { "folkmetal", "Фолк" },
            { "gothicmetal", "Готический" },
            { "industrial", "Индастриал" },
            { "sludgemetal", "Сладж" },
            { "postmetal", "Постметал" },
            { "extrememetal", "Экстрим" },
            { "numetal", "Ню-метал" },
            { "metalcoregenre", "Металкор" },
            { "classicmetal", "Хэви-метал" },
            { "heavymetal", "Хэви-метал" },
            { "thrashmetal", "Трэш-метал" },
            { "deathmetal", "Дэт-метал" },
            { "blackmetal", "Блэк-метал" },
            { "doommetal", "Дум-метал" },
            { "alternativemetal", "Альтернативный метал" },
            { "posthardcore", "Постхардкор" },
            { "hardcore", "Хардкор" },
            { "turkishalternative", "Турецкая альтернативная музыка" },
            { "techno", "Техно" },
            { "house", "Хаус" },
            { "trance", "Транс" },
            { "breakbeatgenre", "Брейкбит" },
            { "bassgenre", "Бейс" },
            { "dnb", "Драм-н-бэйс" },
            { "drum-n-bass", "Драм-н-бэйс" },
            { "dubstep", "Дабстеп" },
            { "triphopgenre", "Трип-хоп" },
            { "ukgaragegenre", "UK Garage" },
            { "idmgenre", "IDM" },
            { "ambientgenre", "Эмбиент" },
            { "newage", "Нью-эйдж" },
            { "new-age", "Нью-эйдж" },
            { "lounge", "Лаундж" },
            { "experimental", "Экспериментальная" },
            { "phonkgenre", "Фонк" },
            { "edmgenre", "EDM" },
            { "rusrap", "Русский рэп" },
            { "foreignrap", "Иностранный рэп" },
            { "turkishrap", "Турецкий рэп и хип-хоп" },
            { "israelirap", "Израильский рэп и хип-хоп" },
            { "soul", "Соул" },
            { "funk", "Фанк" },
            { "tradjazz", "Традиционный" },
            { "conjazz", "Современный" },
            { "modernjazz", "Современный" },
            { "bebopgenre", "Бибоп" },
            { "vocaljazz", "Вокальный джаз" },
            { "smoothjazz", "Смус-джаз" },
            { "bigbands", "Биг бэнды" },
            { "reggaeton", "Реггетон" },
            { "dub", "Даб" },
            { "postpunk", "Постпанк" },
            { "post-punk", "Постпанк" },
            { "rusfolk", "Русская" },
            { "russian", "Русская" },
            { "tatar", "Татарская" },
            { "celtic", "Кельтская" },
            { "balkan", "Балканская" },
            { "eurofolk", "Европейская" },
            { "european", "Европейская" },
            { "jewish", "Еврейская" },
            { "eastern", "Восточная" },
            { "african", "Африканская" },
            { "latinfolk", "Латиноамериканская" },
            { "latin-american", "Латиноамериканская" },
            { "amerfolk", "Американская" },
            { "american", "Американская" },
            { "romances", "Романсы" },
            { "argentinetango", "Аргентинское танго" },
            { "armenian", "Армянская" },
            { "georgian", "Грузинская" },
            { "azerbaijani", "Азербайджанская" },
            { "caucasian", "Кавказская" },
            { "turkishclassical", "Турецкая классическая музыка" },
            { "arabesquemusic", "Арабеска" },
            { "turkishfolk", "Турецкая народная музыка" },
            { "rusestrada", "Русская" },
            { "films", "Из фильмов" },
            { "tvseries", "Из сериалов" },
            { "tv-series", "Из сериалов" },
            { "animated", "Из мультфильмов" },
            { "animated-films", "Из мультфильмов" },
            { "videogame", "Из видеоигр" },
            { "videogame-music", "Из видеоигр" },
            { "animemusic", "Аниме" },
            { "musical", "Мюзиклы" },
            { "bollywood", "Болливуд" },
            { "meditation", "Медитация" },
            { "meditative", "Медитация" },
            { "rusbards", "Русская" },
            { "foreignbard", "Иностранная" },
            { "lullaby", "Колыбельные" },
            { "vocal", "Вокал" },
            { "opera", "Вокал" },
            { "modern", "Современная классика" },
            { "modern-classical", "Современная классика" },
            { "classical", "Мировая классика" },
            { "classicalmasterpieces", "Шедевры мировой классики" },
            { "romancenovel", "Про любовь" },
            { "historicalfiction", "Про историю" },
            { "sciencefiction", "Фантастика" },
            { "fantasyliterature", "Фэнтези" },
            { "actionandadventure", "Приключения и экшн" },
            { "crimeandmystery", "Детективы и триллеры" },
            { "horrorandthrillers", "Ужасы и мистика" },
            { "dramaliterature", "Драматургия" },
            { "childrensliterature", "Книги для детей и подростков" },
            { "community", "Общество и философия" },
            { "work", "О бизнесе" },
            { "technologies", "О технологиях" },
            { "hls", "О здоровом образе жизни" },
            { "selfdevelopment", "О саморазвитии" },
            { "psychologyandphilosophy", "Психология и воспитание" },
            { "religionandspirituality", "О духовном" },
            { "biographyandmemoirs", "Биографии и мемуары" },
            { "popularsciencebooks", "Популярно о науке" },
            { "audiobooksinenglish", "На английском" },
            { "sport", "Спортивная" },
            { "holiday", "Праздничная" },
        };
    }

    public class Artist
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("various")]
        public bool Various { get; set; }

        [JsonPropertyName("composer")]
        public bool Composer { get; set; }

        [JsonPropertyName("cover")]
        public Cover Cover { get; set; }

        [JsonPropertyName("genres")]
        public List<object> Genres { get; set; }
    }

    public class Cover
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        [JsonPropertyName("prefix")]
        public string Prefix { get; set; }
    }

    public class Label
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class LyricsInfo
    {
        [JsonPropertyName("hasAvailableSyncLyrics")]
        public bool HasAvailableSyncLyrics { get; set; }

        [JsonPropertyName("hasAvailableTextLyrics")]
        public bool HasAvailableTextLyrics { get; set; }
    }

    public class Major
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Owner
    {
        [JsonPropertyName("uid")]
        public string Uid { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("avatarHash")]
        public string AvatarHash { get; set; }
    }

    public class Playlist
    {
        [JsonPropertyName("revision")]
        public object Revision { get; set; }

        [JsonPropertyName("kind")]
        public int Kind { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("descriptionFormatted")]
        public string DescriptionFormatted { get; set; }

        [JsonPropertyName("trackCount")]
        public int TrackCount { get; set; }

        [JsonPropertyName("owner")]
        public Owner Owner { get; set; }

        [JsonPropertyName("tracks")]
        public List<Track> Tracks { get; set; }

        [JsonPropertyName("trackIds")]
        public List<string> TrackIds { get; set; }

        [JsonPropertyName("available")]
        public bool Available { get; set; }

        [JsonPropertyName("doNotIndex")]
        public bool DoNotIndex { get; set; }
    }

    public class PlayListModel
    {
        [JsonPropertyName("playlist")]
        public Playlist Playlist { get; set; }
    }

    public class Track
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("realId")]
        public string RealId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("major")]
        public Major Major { get; set; }

        [JsonPropertyName("available")]
        public bool Available { get; set; }

        [JsonPropertyName("availableForPremiumUsers")]
        public bool AvailableForPremiumUsers { get; set; }

        [JsonPropertyName("availableFullWithoutPermission")]
        public bool AvailableFullWithoutPermission { get; set; }

        [JsonPropertyName("availableForOptions")]
        public List<string> AvailableForOptions { get; set; }

        [JsonPropertyName("storageDir")]
        public string StorageDir { get; set; }

        [JsonPropertyName("durationMs")]
        public int DurationMs { get; set; }

        [JsonPropertyName("fileSize")]
        public int FileSize { get; set; }

        [JsonPropertyName("previewDurationMs")]
        public int PreviewDurationMs { get; set; }

        [JsonPropertyName("artists")]
        public List<Artist> Artists { get; set; }

        [JsonPropertyName("albums")]
        public List<Album> Albums { get; set; }

        [JsonPropertyName("coverUri")]
        public string CoverUri { get; set; }

        [JsonPropertyName("ogImage")]
        public string OgImage { get; set; }

        [JsonPropertyName("lyricsAvailable")]
        public bool LyricsAvailable { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("rememberPosition")]
        public bool RememberPosition { get; set; }

        [JsonPropertyName("trackSharingFlag")]
        public string TrackSharingFlag { get; set; }

        [JsonPropertyName("lyricsInfo")]
        public LyricsInfo LyricsInfo { get; set; }

        [JsonPropertyName("trackSource")]
        public string TrackSource { get; set; }

        [JsonPropertyName("prefix")]
        public string Prefix { get; set; }
    }

    public class TrackPosition
    {
        [JsonPropertyName("volume")]
        public int Volume { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }
    }
}
