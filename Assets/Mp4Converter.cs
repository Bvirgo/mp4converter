using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FFmpeg;

public static class Mp4Converter {
	public static void Convert(string audio, string video, string output, ref bool done)
	{
		var inputPath = Application.persistentDataPath + "/" + video;
		var soundPath = Application.persistentDataPath + "/" + audio;
		var outputPath = Application.persistentDataPath + "/" + output;

		FFmpegParser.Handler = new FFmpegHandler(output);

		// -t seconds?
		FFmpegCommands.DirectInput(
			//"-re -f lavfi -i \"movie=\\'" + inputPath + "\\':loop=0, setpts=N/(FRAME_RATE*TB)\" -i '" + soundPath + "' -map 0:v:0 -map 1:a:0 -shortest " + outputPath
			"-y -i \"C:/Users/Bjorn/AppData/LocalLow/Totsj/mp4Converter/VideoBackground.mov\" \"C:/Users/Bjorn/AppData/LocalLow/Totsj/mp4Converter/out.mp4\" \"C:/Users/Bjorn/AppData/LocalLow/Totsj/mp4Converter/Crusade Runner.mp4\""
		);
		
        /*DecodeEncodeData config = new DecodeEncodeData();
        config.fps = 1;
        config.inputPath = inputPath;
        config.soundPath = soundPath;
        config.outputPath = outputPath;

        FFmpegCommands.Encode(config);*/
	}
}

class FFmpegHandler : IFFmpegHandler
{
	string name;

	float t = 0;

    public FFmpegHandler(string name)
    {
		this.name = name;
    }

    public void OnFailure(string msg)
    {
		Debug.Log("FFMPEG: " + name + " failed after " + (Time.time - t) + "s. MSG: " + msg);
    }

    public void OnFinish()
    {
		Debug.Log("FFMPEG: " + name + " finished after " + (Time.time - t) + "s.");
	}

    public void OnProgress(string msg)
    {
		//Debug.Log("FFMPEG: " + name + " progress: " + msg);
	}

    public void OnStart()
    {
		t = Time.time;
		Debug.Log("FFMPEG: " + name + " started");
	}

    public void OnSuccess(string msg)
    {
		Debug.Log("FFMPEG: " + name + " succeded after " + (Time.time - t) + "s. MSG: " + msg);
    }
}