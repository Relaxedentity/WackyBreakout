using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// A pickup block
/// </summary>
public class PickupBlock : Block
{
    [SerializeField]
    Sprite freezerSprite;
    [SerializeField]
    Sprite speedupSprite;

    FreezerEffectActivated freezerEffect;
    SpeedUpEffectActivated speedUpEffect;

    PickupEffect effect;
    int freezerDuration;
    int speedUpDuration;
    float speedUpFactor;

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
        // set points
        points = ConfigurationUtils.PickupBlockPoints;
        
        
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		
	}

	/// <summary>
    /// Sets the effect for the pickup
    /// </summary>
    /// <value>pickup effect</value>
    public PickupEffect Effect
    {
        set
        {
            effect = value;

            // set sprite
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (effect == PickupEffect.Freezer)
            {
                freezerEffect = new FreezerEffectActivated();
                freezerDuration = ConfigurationUtils.FreezerDuration;
                EventManager.AddFreezeInvoker(this);
                spriteRenderer.sprite = freezerSprite;
            }
            else if(effect == PickupEffect.Speedup)
            {
                speedUpEffect = new SpeedUpEffectActivated();
                speedUpDuration = ConfigurationUtils.SpeedUpDuration;
                speedUpFactor = ConfigurationUtils.SpeedUpFactor;
                EventManager.AddSpeedUpInvoker(this);
                spriteRenderer.sprite = speedupSprite;
            }
        }
    }
    public void AddFreezeEventListener(UnityAction<int> freezeEventHandler)
    {
        freezerEffect.AddListener(freezeEventHandler);
    }
    public void AddSpeedUpEventListener(UnityAction<int, float> speedUpEventHandler)
    {
        speedUpEffect.AddListener(speedUpEventHandler);
    }
    protected override void OnCollisionEnter2D(Collision2D other)
    { // don't change default value name.
        if (effect == PickupEffect.Freezer)
        {
            freezerEffect.Invoke(freezerDuration);
        }
        if (effect == PickupEffect.Speedup)
        {
            speedUpEffect.Invoke(speedUpDuration, speedUpFactor);
        }

        base.OnCollisionEnter2D(other);
    }
}
