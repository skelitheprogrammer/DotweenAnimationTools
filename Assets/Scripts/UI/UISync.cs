using UnityEngine;
using UnityEngine.UIElements;

public class UISync : MonoBehaviour
{
    private UIDocument _document;

    private Toggle _loopToggle;
    private TextField _loopCounterField;
    private DropdownField _loopTypeDropdown;

    private DropdownField _easeModeDropdown;
    private DropdownField _animationTypeDropdown;

    private TextField _durationField;
    private TextField _delayField;

    private TextField _xTextField;
    private TextField _yTextField;
    private TextField _zTextField;

    private Button _startAnimationButton;
    private Button _resetAnimationButton;

    /*[SerializeField] private DoTweenAnimationComponent _component;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        var root = _document.rootVisualElement;

        _loopToggle = root.Q<Toggle>("LoopToggle");
        _loopCounterField = root.Q<TextField>("LoopCountText");
        _loopTypeDropdown = root.Q<DropdownField>("LoopTypeDropDown");

        _easeModeDropdown = root.Q<DropdownField>("EaseModeDropDown");
        _animationTypeDropdown = root.Q<DropdownField>("AnimationTypeDropDown");

        _durationField = root.Q<TextField>("DurationText");
        _delayField = root.Q<TextField>("DelayText");

        _xTextField = root.Q<TextField>("XVectorText");
        _yTextField = root.Q<TextField>("YVectorText");
        _zTextField = root.Q<TextField>("ShitVectorText");

        _startAnimationButton = root.Q<Button>("StartAnimationButton");
        _resetAnimationButton = root.Q<Button>("ResetButton");

        _loopTypeDropdown.choices = Enum.GetNames(typeof(LoopType)).ToList();
        _easeModeDropdown.choices = Enum.GetNames(typeof(Ease)).ToList();
        _animationTypeDropdown.choices = Enum.GetNames(typeof(DoTweenAnimationType)).ToList();
    }

    private void Start()
    {
        _loopToggle.value = _component.AnimationSettings.Loop;
        _loopCounterField.value = _component.AnimationSettings.LoopCount.ToString();
        _loopTypeDropdown.value = _component.AnimationSettings.LoopType.ToString();

        _easeModeDropdown.value = _component.AnimationSettings.EaseMode.ToString();
        _animationTypeDropdown.value = _component.AnimationSettings.TypeAnimation.DoTweenAnimationType.ToString();
    }

    private void OnEnable()
    {
        _loopCounterField.RegisterCallback<InputEvent>(x =>
        {
            string numberString = GetNumbers(_loopCounterField.text);

            bool isSucessful = int.TryParse(numberString, out int convertedValue);

            if (isSucessful)
            {
                _component.AnimationSettings.SetLoopCount(convertedValue);
                _loopCounterField.value = numberString;
            }
            else if (_loopCounterField.value == string.Empty)
            {
                _loopCounterField.value = "LoopCount";
                _component.AnimationSettings.SetLoopCount(0);
            }
            else
            {
                _loopCounterField.value = "0";
                _component.AnimationSettings.SetLoopCount(0);
            }
        });

        _loopToggle.RegisterValueChangedCallback(x => 
        {
            _component.AnimationSettings.SetLoopState(x.newValue);
        });

        _loopTypeDropdown.RegisterValueChangedCallback(x =>
        {
            _component.AnimationSettings.SetLoopType(_loopTypeDropdown.index);
        });

        _durationField.RegisterCallback<InputEvent>(x => 
        {
            string numberString = GetNumbers(_durationField.text);

            bool isSucessful = int.TryParse(numberString, out int convertedValue);

            if (isSucessful)
            {
                _component.AnimationSettings.TypeAnimation.SetDuration(convertedValue);
                _durationField.value = numberString;
            }
            else if (_durationField.value == string.Empty)
            {
                _durationField.value = "Duration";
                _component.AnimationSettings.TypeAnimation.SetDuration(0);
            }
            else
            {
                _durationField.value = "0";
                _component.AnimationSettings.TypeAnimation.SetDuration(0);
            }
        });

        _delayField.RegisterCallback<InputEvent>(x =>
        {
            string numberString = GetNumbers(_delayField.text);

            bool isSucessful = int.TryParse(numberString, out int convertedValue);

            if (isSucessful)
            {
                _component.AnimationSettings.SetDelay(convertedValue);
                _delayField.value = numberString;
            }
            else if (_delayField.value == string.Empty)
            {
                _delayField.value = "Delay";
                _component.AnimationSettings.SetDelay(0);
            }
            else
            {
                _delayField.value = "0";
                _component.AnimationSettings.SetDelay(0);
            }
        });

        _xTextField.RegisterCallback<InputEvent>(x =>
        {
            string numberString = GetNumbers(_xTextField.text);

            bool isSucessful = int.TryParse(numberString, out int convertedValue);

            if (isSucessful)
            {
                _component.AnimationSettings.TypeAnimation.SetAxisValue(convertedValue, Vector3.right);
                _xTextField.value = numberString;
            }
            else if (_xTextField.value == string.Empty)
            {
                _xTextField.value = "X";
                _component.AnimationSettings.TypeAnimation.SetAxisValue(0, Vector3.right);
            }
            else
            {
                _xTextField.value = "X";
                _component.AnimationSettings.TypeAnimation.SetAxisValue(0, Vector3.right);
            }
        });

        _yTextField.RegisterCallback<InputEvent>(x =>
        {
            string numberString = GetNumbers(_yTextField.text);

            bool isSucessful = int.TryParse(numberString, out int convertedValue);

            if (isSucessful)
            {
                _component.AnimationSettings.TypeAnimation.SetAxisValue(convertedValue, Vector3.up);
                _yTextField.value = numberString;
            }
            else if (_yTextField.value == string.Empty)
            {
                _yTextField.value = "Y";
                _component.AnimationSettings.TypeAnimation.SetAxisValue(0, Vector3.up);
            }
            else
            {
                _yTextField.value = "Y";
                _component.AnimationSettings.TypeAnimation.SetAxisValue(0, Vector3.up);
            }
        });

        _zTextField.RegisterCallback<InputEvent>(x =>
        {
            string numberString = GetNumbers(_zTextField.text);

            bool isSucessful = int.TryParse(numberString, out int convertedValue);

            if (isSucessful)
            {
                _component.AnimationSettings.TypeAnimation.SetAxisValue(convertedValue, Vector3.forward);
                _zTextField.value = numberString;
            }
            else if (_yTextField.value == string.Empty)
            {
                _zTextField.value = "Z";
                _component.AnimationSettings.TypeAnimation.SetAxisValue(0, Vector3.forward);
            }
            else
            {
                _zTextField.value = "Z";
                _component.AnimationSettings.TypeAnimation.SetAxisValue(0, Vector3.forward);
            }
        });

        _startAnimationButton.clicked += () => StartAnimation();
        _resetAnimationButton.clicked += () => StopAnimation();
    }

    private void OnDisable()
    {
        _loopCounterField.UnregisterCallback<InputEvent>(x =>
        {
            string numberString = GetNumbers(_loopCounterField.text);

            bool isSucessful = int.TryParse(numberString, out int convertedValue);

            if (isSucessful)
            {
                _component.AnimationSettings.SetLoopCount(convertedValue);
                _loopCounterField.value = numberString;
            }
            else if (_loopCounterField.value == string.Empty)
            {
                _loopCounterField.value = "LoopCount";
                _component.AnimationSettings.SetLoopCount(0);
            }
            else
            {
                _loopCounterField.value = "0";
                _component.AnimationSettings.SetLoopCount(0);
            }
        });

        _loopToggle.UnregisterValueChangedCallback(x =>
        {
            _component.AnimationSettings.SetLoopState(x.newValue);
        });

        _loopTypeDropdown.UnregisterValueChangedCallback(x =>
        {
            _component.AnimationSettings.SetLoopType(_loopTypeDropdown.index);
        });

        _durationField.UnregisterCallback<InputEvent>(x =>
        {
            string numberString = GetNumbers(_durationField.text);

            bool isSucessful = int.TryParse(numberString, out int convertedValue);

            if (isSucessful)
            {
                _component.AnimationSettings.TypeAnimation.SetDuration(convertedValue);
                _durationField.value = numberString;
            }
            else if (_durationField.value == string.Empty)
            {
                _durationField.value = "Duration";
                _component.AnimationSettings.TypeAnimation.SetDuration(0);
            }
            else
            {
                _durationField.value = "0";
                _component.AnimationSettings.TypeAnimation.SetDuration(0);
            }
        });

        _delayField.UnregisterCallback<InputEvent>(x =>
        {
            string numberString = GetNumbers(_delayField.text);

            bool isSucessful = int.TryParse(numberString, out int convertedValue);

            if (isSucessful)
            {
                _component.AnimationSettings.SetDelay(convertedValue);
                _delayField.value = numberString;
            }
            else if (_delayField.value == string.Empty)
            {
                _delayField.value = "Delay";
                _component.AnimationSettings.SetDelay(0);
            }
            else
            {
                _delayField.value = "0";
                _component.AnimationSettings.SetDelay(0);
            }
        });

        _xTextField.UnregisterCallback<InputEvent>(x =>
        {
            string numberString = GetNumbers(_xTextField.text);

            bool isSucessful = int.TryParse(numberString, out int convertedValue);

            if (isSucessful)
            {
                _component.AnimationSettings.TypeAnimation.SetAxisValue(convertedValue, Vector3.right);
                _xTextField.value = numberString;
            }
            else if (_xTextField.value == string.Empty)
            {
                _xTextField.value = "X";
                _component.AnimationSettings.TypeAnimation.SetAxisValue(0, Vector3.right);
            }
            else
            {
                _xTextField.value = "X";
                _component.AnimationSettings.TypeAnimation.SetAxisValue(0, Vector3.right);
            }
        });

        _yTextField.UnregisterCallback<InputEvent>(x =>
        {
            string numberString = GetNumbers(_yTextField.text);

            bool isSucessful = int.TryParse(numberString, out int convertedValue);

            if (isSucessful)
            {
                _component.AnimationSettings.TypeAnimation.SetAxisValue(convertedValue, Vector3.up);
                _yTextField.value = numberString;
            }
            else if (_yTextField.value == string.Empty)
            {
                _yTextField.value = "Y";
                _component.AnimationSettings.TypeAnimation.SetAxisValue(0, Vector3.up);
            }
            else
            {
                _yTextField.value = "Y";
                _component.AnimationSettings.TypeAnimation.SetAxisValue(0, Vector3.up);
            }
        });

        _zTextField.UnregisterCallback<InputEvent>(x =>
        {
            string numberString = GetNumbers(_zTextField.text);

            bool isSucessful = int.TryParse(numberString, out int convertedValue);

            if (isSucessful)
            {
                _component.AnimationSettings.TypeAnimation.SetAxisValue(convertedValue, Vector3.forward);
                _zTextField.value = numberString;
            }
            else if (_yTextField.value == string.Empty)
            {
                _zTextField.value = "Z";
                _component.AnimationSettings.TypeAnimation.SetAxisValue(0, Vector3.forward);
            }
            else
            {
                _zTextField.value = "Z";
                _component.AnimationSettings.TypeAnimation.SetAxisValue(0, Vector3.forward);
            }
        });

        _startAnimationButton.clicked -= () => StartAnimation();
        _resetAnimationButton.clicked -= () => StopAnimation();
    }

    private string GetNumbers(string input)
    {
        input = new string(input.Where(c => char.IsNumber(c)).ToArray());
        string output = input;

        bool check = output == "00";

        if (check)
        {
            output = "0";
        }
        else
        {
            output = output.TrimStart('0');
        }

        return output;
    }

    private void StartAnimation()
    {
        _component.PlayTweener();
    }

    private void StopAnimation()
    {
        _component.StopTweener();
    }
*/
}
