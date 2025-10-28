namespace HeroComponents
{
    public class HeroVampirismAbility : VampirismAbility
    {
        private HeroInputReader _inputReader;

        protected override void Awake()
        {
            base.Awake();
            
            _inputReader = GetComponent<HeroInputReader>();
        }

        private void OnEnable() => 
            _inputReader.Vampirized += EnableVampirism;

        private void OnDisable() => 
            _inputReader.Vampirized -= EnableVampirism;
    }
}