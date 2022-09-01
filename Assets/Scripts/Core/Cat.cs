using UnityEngine;

public class Cat : MonoBehaviour
{
    Characteristic[] characteristics;
    BreedingController breedingController;
    SpriteRenderer spriteRenderer;
    Dragger dragger;

    private void Awake()
    {
        breedingController = GameObject.Find("Breeding Manager").GetComponent<BreedingController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        dragger = GetComponent<Dragger>();

        ApplyTexture();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Collision {gameObject.name} with {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("Cat") && dragger.isSelected)
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            breedingController.Breed(this, collision.gameObject.GetComponent<Cat>());
        }
    }

    void ApplyTexture()
    {
        if (characteristics == null)
        {
            spriteRenderer.color = Color.white;
        }
    }
}
