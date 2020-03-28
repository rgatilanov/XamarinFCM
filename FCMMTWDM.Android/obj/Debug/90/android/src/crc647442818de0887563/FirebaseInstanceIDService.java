package crc647442818de0887563;


public class FirebaseInstanceIDService
	extends com.google.firebase.iid.FirebaseInstanceIdService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTokenRefresh:()V:GetOnTokenRefreshHandler\n" +
			"";
		mono.android.Runtime.register ("FCMMTWDM.Droid.FirebaseInstanceIDService, FCMMTWDM.Android", FirebaseInstanceIDService.class, __md_methods);
	}


	public FirebaseInstanceIDService ()
	{
		super ();
		if (getClass () == FirebaseInstanceIDService.class)
			mono.android.TypeManager.Activate ("FCMMTWDM.Droid.FirebaseInstanceIDService, FCMMTWDM.Android", "", this, new java.lang.Object[] {  });
	}


	public void onTokenRefresh ()
	{
		n_onTokenRefresh ();
	}

	private native void n_onTokenRefresh ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
