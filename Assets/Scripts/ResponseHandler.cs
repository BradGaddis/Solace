using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResponseHandler : MonoBehaviour {
    // public List<string> tests = new List<string>();
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;

    public void ShowResponses(Response[] responses)
    {
        float responseBoxHeight = 0;

        foreach(Response response in responses)
        {
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.GetComponent<TMP_Text>().text = response.ResponseText;
            // responseButton.GetComponent<Button>().onClick.AddListener(call() => OnPickedResponse());

            responseBoxHeight += responseButtonTemplate.sizeDelta.y;
        }

        // responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight.y);
        responseBox.gameObject.SetActive(true);
    }

    public void OnPickedResponse()
    {
    }
 }