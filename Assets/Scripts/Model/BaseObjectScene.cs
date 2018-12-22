using System;
using UnityEngine;

namespace MyProject
{
           public abstract class BaseObjectScene : MonoBehaviour
        {
            private int layer; // слой 
            private Color color; // цвет
            private bool isVisible; // отображается ли объект
            [HideInInspector] public Rigidbody rigidbody;



            protected virtual void Awake()
            {
                rigidbody = GetComponent<Rigidbody>();
            }

            #region Свойства

            /// <summary>
            /// Имя объекта
            /// </summary>
            public string Name
            {
                get { return gameObject.name; }
                set { gameObject.name = value; }
            }
            /// <summary>
            /// Слой объекта
            /// </summary>
            public int Layer
            {
                get { return layer; }
                set
                {
                    layer = value;
                    AskLayer(transform, value);
                }
            }

            /// <summary>
            /// Цвет материала объекта
            /// </summary>
            public Color Color
            {
                get { return color; }
                set
                {
                    color = value;
                    AskColor(transform, color);
                }
            }

            public bool IsVisible
            {
                get { return isVisible; }
                set
                {
                    isVisible = value;
                    var tempRenderer = GetComponent<Renderer>(); // получаем ссылку на рендерер
                    if (tempRenderer)
                        tempRenderer.enabled = isVisible;// отрисовка по значению (true/false)
                    if (transform.childCount <= 0) return;
                    foreach (Transform d in transform) // отрисовка дочерних объектов..
                    {
                        tempRenderer = d.gameObject.GetComponent<Renderer>();
                        if (tempRenderer)
                            tempRenderer.enabled = isVisible;

                    }
                }
            }

            #endregion

            #region Частные функции
            /// <summary>
            /// Выставляет номер слоя себе и всем дочерним объектам в независимости от уровня вложенности
            /// </summary>
            /// <param name="obj">Объект</param>
            /// <param name="lvl">Номер слоя</param>
            private void AskLayer(Transform obj, int lvl)
            {
                obj.gameObject.layer = lvl;
                if (obj.childCount <= 0) return;
                foreach (Transform d in obj)
                {
                    AskLayer(d, lvl);
                }
            }
            /// <summary>
            /// Устанавливает цвет себе и всем дочерним объектам
            /// </summary>
            /// <param name="obj">Объект</param>
            /// <param name="color">Цвет</param>
            private void AskColor(Transform obj, Color color)
            {
                foreach (var curMaterial in obj.GetComponent<Renderer>().materials)
                {
                    curMaterial.color = color;
                }
                if (obj.childCount <= 0) return;
                foreach (Transform d in obj)
                {
                    AskColor(d, color);
                }
            }


            #endregion

            public bool IsRigitBody()
            {
                return rigidbody;
            }



            /// <summary>
            /// Выключает физику у объекта и его детей
            /// </summary>
            public void DisableRigidBody()
            {
                if (!IsRigitBody()) return;

                Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
                foreach (var rb in rigidbodies)
                {
                    rb.isKinematic = true;
                }
            }

            /// <summary>
            /// Включает физику у объекта и его детей
            /// </summary>
            public void EnableRigidBody()
            {
                if (!IsRigitBody()) return;
                Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
                foreach (var rb in rigidbodies)
                {
                    rb.isKinematic = false;
                }
            }


            /// <summary>
            /// Включает физику у объекта и его детей, дает пинка * и силу (земли и огурцов)...
            /// </summary>
            public void EnableRigidBody(float force)
            {
                EnableRigidBody();
                //Rigidbody.isKinematic = false;
                rigidbody.AddForce(transform.forward * force);
            }



            /// <summary>
            /// Замораживает или размораживает физическую трансформацию объекта
            /// </summary>
            /// <param name="rigidbodyConstraints">Трансформацию которую нужно заморозить</param>
            public void ConstraintsRigidBody(RigidbodyConstraints rigidbodyConstraints)
            {
                Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
                foreach (var rb in rigidbodies)
                {
                    rb.constraints = rigidbodyConstraints;
                }
            }

            public void SetActive(bool value)
            {
                IsVisible = value;

                var tempCollider = GetComponent<Collider>();
                if (tempCollider)
                {
                    tempCollider.enabled = value;
                }
            }

            protected void MyInvoke(Action method, float time)
            {
                Invoke(method.Method.Name, time);
            }

            protected void MyCancelInvoke(Action method)
            {
                CancelInvoke(method.Method.Name);
            }

            protected void MyInvokeRepeating(Action method, float time, float repeatRate)
            {
                InvokeRepeating(method.Method.Name, time, repeatRate);
            }

            protected virtual void OnDisable()
            {
                CancelInvoke();
            }

        }
    }
