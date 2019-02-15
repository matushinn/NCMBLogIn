using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;



public class UserAuth : MonoBehaviour
{

    public string userName;
    public string password;
    public string email;

    // Use this for initialization
    void Start()
    {
        //SignUp(userName, password, email);
        LogIn(userName, password);
    }

    public void SignUp(string userName, string password, string email)
    {

        //NCMBUserのインスタンス作成
        NCMBUser user = new NCMBUser();

        //ユーザー名とパスワードの設定
        user.UserName = userName;
        user.Password = password;
        user.Email = email;

        //会員登録をおこなう
        user.SignUpAsync((NCMBException e) =>
        {
            if (e != null)
            {
                Debug.Log("新規登録に失敗:" + e.ErrorMessage);
            }
            else
            {
                Debug.Log("新規登録に成功");
            }
        });
    }

    //アプリからログインする
    public void LogIn(string userName,string password){
        //会員登録をおこなう
        NCMBUser.LogInAsync(userName,password,(NCMBException e) =>
        {
            if (e != null)
            {
                Debug.Log("ログインに失敗:" + e.ErrorMessage);
            }
            else
            {
                Debug.Log("ログインに成功");
                SetPoint(5);
            }
        });
    }

    //会員登録にデータを保存する
    public void SetPoint(int num){
        if(NCMBUser.CurrentUser != null){
            NCMBUser.CurrentUser["Point"] = num;

            NCMBUser.CurrentUser.SaveAsync((NCMBException e) =>
            {
                if (e != null)
                {
                    Debug.Log("保存に失敗:"+ e.ErrorMessage);
                }
                else
                {
                    Debug.Log("保存に成功");
                }
            });
        }
    }

    //アプリからログアウトする
    public void LogOut(){
        NCMBUser.LogOutAsync((NCMBException e) =>
        {
            if (e != null)
            {
                Debug.Log("ログアウトに失敗" + e.ErrorMessage);
            }
            else
            {
                Debug.Log("ログアウトに成功");
            }
        });
    }
}
