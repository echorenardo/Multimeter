using UnityEngine;
using Initializing;
using InputControlling;
using Multimeter;
using Multimeter.View;
using MeasuringTarget;

public class DIContainer : MonoBehaviour
{
    [SerializeField] private InputController _inputController;
    [SerializeField] private MouseInterceptor _multimeterScrollerMouseInterceptor;
    [SerializeField] private MultimeterScrollerView _multimeterScrollerView;
    [SerializeField] private MultimeterDisplayView _multimeterDisplayView;
    [SerializeField] private MeasuredValuesUI _measuredValuesUI;

    private Initializer _initializer;
    private MultimeterModel _multimeter;
    private IMeasurementTarget _measuredTarget;
    private MultimeterPresenter _multimeterPresenter;

    private void Awake()
    {
        _initializer = new();

        _measuredTarget = new MeasurementTarget(1000, 400);
        _multimeter = new(_inputController, _measuredTarget);
        _multimeterPresenter = new(_multimeter, _multimeterScrollerView, _multimeterDisplayView,
                                        _measuredValuesUI, _multimeterScrollerMouseInterceptor);

        _multimeterScrollerMouseInterceptor.OnConstruct(_inputController);
    }

    private void Start()
    {
        _initializer.Initialize(new()
        {  
            _multimeterScrollerView,
            _measuredValuesUI,
            _multimeterPresenter,
            _multimeter
        });
    }

    private void OnDestroy()
    {
        _initializer.Dispose(new()
        {
            _multimeter,
            _multimeterPresenter
        });
    }
}