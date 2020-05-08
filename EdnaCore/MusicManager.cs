using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Media;

namespace EdnaCore
{
    public class MusicManager
    {
        private Song _currentTrack;

        private void MediaPlayerOnMediaStateChanged(object? sender, EventArgs e)
        {
            if (_currentTrack == null)
                return;

            if (MediaPlayer.State == MediaState.Playing)
                MediaPlayer.Play(_currentTrack);
        }

        public void PlaySong(Song song, bool restart = false)
        {
            if (_currentTrack != null && song.Name == _currentTrack.Name && !restart)
                return;

            if (_currentTrack != null)
                Stop();

            MediaPlayer.Play(song);
            MediaPlayer.MediaStateChanged += MediaPlayerOnMediaStateChanged;
            _currentTrack = song;
        }

        public void Stop()
        {
            MediaPlayer.Stop();
            _currentTrack = null;
        }
    }
}
