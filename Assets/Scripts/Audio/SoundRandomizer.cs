using System.Linq;
using MyBox;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Audio
{
    public class SoundRandomizer : MonoBehaviour
    {
        public Track[] tracks;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponentInParent<AudioSource>();
        }

        private AudioClip GetRandomClip()
        {
            int totalWeight = tracks.Sum(t => t.weight);

            int r = Random.Range(0, totalWeight);
            int index = 0;
            foreach (Track t in tracks)
            {
                index += t.weight;
                if (r < index)
                {
                    return t.clip;
                }
            }

            return tracks[Random.Range(0,tracks.Length)].clip;
        }

        [ButtonMethod]
        public void PlayRandomClip()
        {
            if (_audioSource == null) Awake();
            _audioSource.PlayOneShot(GetRandomClip());
        }
    }
}
