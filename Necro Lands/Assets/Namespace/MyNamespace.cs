using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Todo
{
    public class Action
    {
     
        public static Vector3 GetLocation(string n)
        {
            return new Vector3(GameObject.Find(n).transform.position.x, GameObject.Find(n).transform.position.y, GameObject.Find(n).transform.position.z);
        }

        public static void SetLocation(string n, Vector3 vec)
        {
            GameObject.Find(n).transform.position = vec;
        }
        public static Vector3 GetLocation(GameObject g)
        {
            return new Vector3(g.transform.position.x, g.transform.position.y, g.transform.position.z);
        }

        public static void SetLocation(GameObject g, Vector3 vec)
        {
            g.transform.position = vec;
        }


        public static void StandardMove(GameObject g, float speed)
        {
            if (Input.GetKey(KeyCode.W))
            {
                g.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                g.transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                g.transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                g.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }

        public static void MoveX(string n, float m)
        {
            GameObject.Find(n).transform.Translate(Vector3.right * m * Time.deltaTime);
        }

        public static void MoveY(string n, float m)
        {
            GameObject.Find(n).transform.Translate(Vector3.up * m * Time.deltaTime);
        }

        public static void MoveZ(string n, float m)
        {
            GameObject.Find(n).transform.Translate(Vector3.forward * m * Time.deltaTime);
        }

        public static void SetX(string n, float m)
        {
            GameObject.Find(n).transform.position = new Vector3(m, GameObject.Find(n).transform.position.y, GameObject.Find(n).transform.position.z);
        }

        public static void SetY(string n, float m)
        {
            GameObject.Find(n).transform.position = new Vector3(GameObject.Find(n).transform.position.x, m, GameObject.Find(n).transform.position.z);
        }

        public static void SetZ(string n, float m)
        {
            GameObject.Find(n).transform.position = new Vector3(GameObject.Find(n).transform.position.x, GameObject.Find(n).transform.position.y, m);
        }

        public static void UpScaleX(string n, float f)
        {
            GameObject.Find(n).transform.localScale = new Vector3(GameObject.Find(n).transform.localScale.x + f, GameObject.Find(n).transform.localScale.y, GameObject.Find(n).transform.localScale.z);
        }

        public static void UpScaleY(string n, float f)
        {
            GameObject.Find(n).transform.localScale = new Vector3(GameObject.Find(n).transform.localScale.x, GameObject.Find(n).transform.localScale.y + f, GameObject.Find(n).transform.localScale.z);
        }

        public static void UpScaleZ(string n, float f)
        {
            GameObject.Find(n).transform.localScale = new Vector3(GameObject.Find(n).transform.localScale.x, GameObject.Find(n).transform.localScale.y, GameObject.Find(n).transform.localScale.z + f);
        }

        public static GameObject[] FindEnemy(string tag)
        {
            return GameObject.FindGameObjectsWithTag(tag);
        }
        public static void UIMoveX(string n, float f)
        {
            GameObject.Find(n).GetComponent<RectTransform>().Translate(Vector3.right * f * Time.deltaTime);
        }
        public static void UIMoveY(string n, float f)
        {
            GameObject.Find(n).GetComponent<RectTransform>().Translate(Vector3.up * f * Time.deltaTime);
        }

        public static void UIMoveZ(string n, float f)
        {
            GameObject.Find(n).GetComponent<RectTransform>().Translate(Vector3.forward * f * Time.deltaTime);
        }


    }

    public class Menu
    {
        public static void E2D(GameObject g)
        {
            g.GetComponent<SpriteRenderer>().enabled = true;
        }
        public static void D2D(GameObject g)
        {
            g.GetComponent<SpriteRenderer>().enabled = false;
        }

        public static void E3D(GameObject g)
        {
            g.GetComponent<MeshRenderer>().enabled = true;
        }
        public static void D3D(GameObject g)
        {
            g.GetComponent<MeshRenderer>().enabled = false;
        }

        public static void E2D(string n)
        {
            GameObject.Find(n).GetComponent<SpriteRenderer>().enabled = true;
        }
        public static void D2D(string n)
        {
            GameObject.Find(n).GetComponent<SpriteRenderer>().enabled = false;
        }

        public static void E3D(string n)
        {
            GameObject.Find(n).GetComponent<MeshRenderer>().enabled = true;
        }
        public static void D3D(string n)
        {
            GameObject.Find(n).GetComponent<MeshRenderer>().enabled = false;
        }

        public static bool En2D(string n)
        {
            return GameObject.Find(n).GetComponent<SpriteRenderer>().enabled;
        }

        public static bool En3D(string n)
        {
            return GameObject.Find(n).GetComponent<MeshRenderer>().enabled;
        }

        public static void SetUIText(string n)
        {
            GameObject.Find(n).GetComponent<Text>().text = n;
        }


        public static void Set3DText(string n)
        {
            GameObject.Find(n).GetComponent<TextMesh>().text = n;
        }

        public static bool GetUIText(string n)
        {
           return GameObject.Find(n).GetComponent<Text>().text == "";
        }


        public static bool Get3DText(string n)
        {
            return GameObject.Find(n).GetComponent<TextMesh>().text == "";
        }
        public static void SetSprite(string n, Sprite sp)
        {
            GameObject.Find(n).GetComponent<SpriteRenderer>().sprite = sp;
        }

        public static void SetColor(string n, Color col)
        {
            GameObject.Find(n).GetComponent<SpriteRenderer>().color = col;
        }

        public static Sprite GetSprite(string n)
        {
           return GameObject.Find(n).GetComponent<SpriteRenderer>().sprite;
        }

        public static Color GetColor(string n)
        {
            return GameObject.Find(n).GetComponent<SpriteRenderer>().color;
        }

        public static void ECanvas(string n)
        {
            GameObject.Find(n).GetComponent<Canvas>().enabled = true;
        }

        public static void DCanvas(string n)
        {
            GameObject.Find(n).GetComponent<Canvas>().enabled = false;
        }

     
    }


}

