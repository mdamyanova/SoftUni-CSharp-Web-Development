import sys


class Song:

    def __init__(self, song_name, singer_name, duration):
        self.song_name = song_name
        self.singer_name = singer_name
        self.duration = duration

        if any(value is None for value in [self.song_name, self.singer_name, self.duration]):
            raise ValueError("Each song must have song name, singer name and duration")

    def __str__(self):
        return "Song name: {}\r\nSinger name: {}\r\nDuration: {}\r\n".format(
            self.song_name, self.singer_name, self.duration
        )


def main():
    song1 = Song("Ad i Ray", "Slavi Trifonov and Ku-ku band", "03:45")
    song2 = Song("Gradyl Iliya kiliya", "Bay Trifon", "05:00")
    print(song1)
    print(song2)


if __name__ == "__main__":
    sys.exit(main())
