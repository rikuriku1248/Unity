using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnimationScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	Image buttonImage;
	public Sprite[] stage1ButtonImg;
	bool button_animation_flag = false;
	int animation_index = 0;
	int i = 0;

	void Start () {
		buttonImage = GetComponent<Image> ();
	}


	void Update () {
		if(button_animation_flag){
			buttonImage.sprite = stage1ButtonImg[animation_index];
			i++;
			if(i % 10 == 0){
				animation_index++;
				if(animation_index == 19){
					animation_index = 0;
					i = 0;
				}
			}
		}
	}

	public void OnPointerEnter( PointerEventData eventData )
	{
		//Debug.Log ("Enter");
		button_animation_flag = true;
	}

	public void OnPointerExit( PointerEventData eventData )
	{
		//Debug.Log ("Exit");
		button_animation_flag = false;
		animation_index = 0;
		buttonImage.sprite = stage1ButtonImg[animation_index];
	}
}